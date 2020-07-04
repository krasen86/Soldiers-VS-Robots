﻿using System.Collections;
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
	[SerializeField] private GameObject pickUpText;
	[SerializeField] private Image healthBarImage;
	[SerializeField] private Slider healthBar;
	private float zoomFactor;
	public static bool inRange;

	[SerializeField] private Camera mainCamera;

	[SerializeField] private TMP_Text missionTime;

	private GameState missionState;
	private PlayerState playerState;

	void Awake()
	{
		inRange = false;
		playerState = PlayerState.Instance;
		missionState = GameState.Instance;
	}

    void Start()
    {		
	    zoomFactor = 5f;
	    cameraMovementFactor = 0.2f;
        playerName.text = "Player: " + playerState.PlayerName;
    }

    void Update()
    {

	    if(!pickUpText.activeSelf && inRange)
		{
			ShowPickUpText();
		}
		else if(pickUpText.activeSelf && !inRange)
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

	    TimeSpan timeSpan = TimeSpan.FromSeconds(missionState.MissionTime);
		
	    missionTime.text = "Time left: " + timeSpan.ToString("m':'ss");
	    if (missionState.MissionTime<=60)
	    {
		    missionTime.color  = Color.red;
	    }
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
	    cameraZoom();

        if(mainCamera.transform.position != player.transform.position)
		{
			offset = new Vector3(player.transform.position.x, player.transform.position.y ,mainCamera.transform.position.z);
			offset.x = Mathf.Clamp(offset.x, minCamera.x, maxCamera.x);
			offset.y = Mathf.Clamp(offset.y, minCamera.y, maxCamera.y);
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, offset, cameraMovementFactor);
			mainCamera.orthographicSize = zoomFactor;
		}
    }

    private void cameraZoom()
    {
	    
	    if (Input.GetAxis("Mouse ScrollWheel") > 0)
	    {
		    if (zoomFactor > 2)
		    {
			    zoomFactor -= 1;
		    }
	    }
	    if (Input.GetAxis("Mouse ScrollWheel") < 0)
	    {
		    if (zoomFactor < 4)
		    {
			    zoomFactor += 1;
		    }
	    }

	    
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