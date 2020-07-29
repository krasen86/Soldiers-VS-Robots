using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioSelectionScript : MonoBehaviour
{
    private PlayerState playerState;
    
    public void StartMission1() 
    {
        
        playerState.SetPlayerState();        
        SceneManager.LoadScene(GameConstants.sceneScenarioOne);

        
    }
    public void StartMission2() 
    {
        playerState.SetPlayerState();
        SceneManager.LoadScene(GameConstants.sceneScenarioTwo);
    }
    public void BackToPrepareGame() 
    {
        SceneManager.LoadScene(GameConstants.scenePrepareGame);
    }

    public void Start()
    {
        playerState = PlayerState.Instance;
    }
   public void Update()
   {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Screen.fullScreen = false;
        }
    }
}
