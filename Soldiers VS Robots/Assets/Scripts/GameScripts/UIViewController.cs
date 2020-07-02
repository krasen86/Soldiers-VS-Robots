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
	private float cameraMovementFactor;
    private Vector3 offset;
	[SerializeField] private Vector2 maxCamera;
	[SerializeField] private Vector2 minCamera;
	[SerializeField] private TMP_Text playerName;
	[SerializeField] private TMP_Text playerScore;
	[SerializeField] private TMP_Text playerBullets;
	[SerializeField] private Image healthBarImage;
	[SerializeField] private Slider healthBar;
	
	[SerializeField] private Camera mainCamera;

	[SerializeField] private TMP_Text missionTime;

	private GameState missionState;
	private PlayerState playerState;

	void Awake()
	{
		playerState = PlayerState.Instance;
		missionState = GameState.Instance;
	}
    void Start()
    {
        cameraMovementFactor = 0.2f;
        playerName.text = "Player: " + playerState.PlayerName;
    }

    void Update()
    {
	    healthBar.value = playerState.PlayerHealth;
	    
	    if (healthBar.value <= healthBar.minValue)
	    {
		    healthBarImage.enabled = false;
	    }

	    if (healthBar.value > healthBar.minValue && !healthBarImage.enabled)
	    {
		    healthBarImage.enabled = true;
	    }

	    TimeSpan timeSpan = TimeSpan.FromSeconds(missionState.MissionTime);
	    missionTime.text = "Time left: " + timeSpan.ToString("m':'ss");
	    UpdatePlayerInfo();
    }
    
    public void ExitGame()
    {
	    SceneManager.LoadScene("GameEnded");

    }

    private void UpdatePlayerInfo()
    {
	    playerScore.text = "Score: " + playerState.PlayerScore;
	    playerBullets.text = "Bullets: " + playerState.PlayerBullets;
    }
    void LateUpdate()
    {
        if(mainCamera.transform.position != player.transform.position)
		{
			offset = new Vector3(player.transform.position.x, player.transform.position.y ,mainCamera.transform.position.z);
			offset.x = Mathf.Clamp(offset.x, minCamera.x, maxCamera.x);
			offset.y = Mathf.Clamp(offset.y, minCamera.y, maxCamera.y);
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, offset, cameraMovementFactor);
		}
    }
}
