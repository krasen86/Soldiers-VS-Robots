using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

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
        playerName.text = playerState.PlayerName;

    }

    void Update()
    {
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
        if(transform.position != player.transform.position)
		{
			offset = new Vector3(player.transform.position.x, player.transform.position.y ,transform.position.z);
			offset.x = Mathf.Clamp(offset.x, minCamera.x, maxCamera.x);
			offset.y = Mathf.Clamp(offset.y, minCamera.y, maxCamera.y);

			transform.position = Vector3.Lerp(transform.position, offset, cameraMovementFactor);
		}
    }
}
