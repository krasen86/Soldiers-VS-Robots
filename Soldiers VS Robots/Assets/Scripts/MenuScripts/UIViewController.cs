using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIViewController : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 maxCamera;
	[SerializeField] private Vector2 minCamera;
	[SerializeField] private TMP_Text playerName;
	[SerializeField] private TMP_Text playerScore;
	[SerializeField] private TMP_Text playerBullets;
	[SerializeField] private GameObject pickUpText;
	[SerializeField] private Image healthBarImage;
	[SerializeField] private Slider healthBar;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private TMP_Text missionTime;
	private GameState gameState;
	private PlayerState playerState;
	private float zoomCam;
	private Vector3 offset;
	public static bool itemInRange;

	void Awake()
	{
		playerState = PlayerState.Instance;
		playerState.ItemInRange = false;
		gameState = GameState.Instance;
	}

    void Start()
    {
	    zoomCam = mainCamera.orthographicSize;
        playerName.text = GameConstants.playerNameHeader + playerState.PlayerName;
    }

    void Update()
    {

	    if(!pickUpText.activeSelf && playerState.ItemInRange)
		{
			ShowPickUpText();
		}
		else if(pickUpText.activeSelf && !playerState.ItemInRange)
		{
			HidePickUpText();
		}

		
	    healthBar.value = playerState.PlayerHealth;
	    
	    if (healthBar.value <= healthBar.minValue)
	    {
		    healthBarImage.enabled = false;
	    }

	    if (healthBar.value > healthBar.minValue && !healthBarImage.enabled)
	    {
		    healthBarImage.enabled = true;
	    }
	    // Since the player can have more then 100 health the health bar is resized
	    if(playerState.PlayerHealth > healthBar.maxValue)
	    {
		    healthBar.maxValue = playerState.PlayerHealth;
	    }
	    // Display countdown timer in minetes and seconds
	    TimeSpan timeSpan = TimeSpan.FromSeconds(gameState.MissionTime);
	    missionTime.text = GameConstants.missionTimeHeader + timeSpan.ToString("m':'ss");
	    if (gameState.MissionTime <= GameConstants.missionTimeLowerLimit)
	    {
		    missionTime.color  = Color.red;
	    }
	    UpdatePlayerInfo();
    }
    
    public void ExitGame()
    {
		DataIOStream.AddPlayer(playerState.PlayerName, playerState.PlayerScore);
	    SceneManager.LoadScene(GameConstants.sceneGameOver);
    }

    private void UpdatePlayerInfo()
    {
	    playerScore.text = GameConstants.playerScoreHeader + playerState.PlayerScore;
	    playerBullets.text = GameConstants.playerBulletsHeader + playerState.PlayerBullets;
    }

    void LateUpdate()
    {
	    CameraZoom();
		//Follow player
        if(mainCamera.transform.position != player.transform.position)
		{
			offset = new Vector3(player.transform.position.x, player.transform.position.y ,mainCamera.transform.position.z);
			offset.x = Mathf.Clamp(offset.x, minCamera.x, maxCamera.x);
			offset.y = Mathf.Clamp(offset.y, minCamera.y, maxCamera.y);
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, offset, GameConstants.cameraMovementFactor);
			
		}
    }

    private void CameraZoom()
    {
	    zoomCam -= Input.GetAxis(GameConstants.mouseScroll) * GameConstants.cameraZoomFactor;
	    zoomCam = Mathf.Clamp(zoomCam, GameConstants.cameraZoomMin, GameConstants.cameraZoomMax);
	    mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize,zoomCam, Time.deltaTime * GameConstants.timeModifier);
    }

	public void ShowPickUpText()
	{
		pickUpText.SetActive(true);

	}

	public void HidePickUpText()
	{
		pickUpText.SetActive(false);
	}
}
