using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIViewController : MonoBehaviour
{


    [SerializeField] private GameObject player;
	private float cameraMovementFactor;
    private Vector3 offset;
	[SerializeField] private Vector2 maxCamera;
	[SerializeField] private Vector2 minCamera;
	[SerializeField] private TMP_Text playerName;

	[SerializeField] private TMP_Text missionTime;

	[SerializeField] private GameState missionState;

    void Start()
    {
        cameraMovementFactor = 0.2f;
        Player player = new Player();
        playerName.text = player.GetPlayerName();

    }

    void Update()
    {
	    TimeSpan timeSpan = TimeSpan.FromSeconds(missionState.MissionTime);
	    missionTime.text = "Time left: " + timeSpan.ToString("m':'ss"); 
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
