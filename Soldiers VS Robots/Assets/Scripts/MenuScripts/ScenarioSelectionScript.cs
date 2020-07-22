using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioSelectionScript : MonoBehaviour
{
    private PlayerState playerState;
    
    public void StartMission1() 
    {
        playerState = PlayerState.Instance;
        playerState.SetPlayerState();
        SceneManager.LoadScene("Scenario1");
    }
    public void StartMission2() 
    {
        playerState = PlayerState.Instance;
        playerState.SetPlayerState();
        SceneManager.LoadScene("Scenario2");
    }
    public void BackToPrepareGame() 
    {
        SceneManager.LoadScene("PrepareGame");
    }
   public void Update()
   {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Screen.fullScreen = false;
        }
    }
}
