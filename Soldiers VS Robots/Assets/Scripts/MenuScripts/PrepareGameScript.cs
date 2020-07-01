using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PrepareGameScript : MonoBehaviour
{
	[SerializeField] private TMP_InputField playerName;
	[SerializeField] private PlayerState playerState;
	[SerializeField] private GameState gameState;

	
    public void SelectScenario()
    {
	    playerState = PlayerState.Instance;
		if(playerName.text == null && playerName.text == "")
		{
			playerName.placeholder.GetComponent<TMP_Text>().text = "Error";
		}
		else
		{		
			
			playerState.PlayerName = playerName.text;
            SceneManager.LoadScene("ScenarioSelection");
		}

    }

    public void SetGameDifficulty(int difficulty)
    {
	    gameState = GameState.Instance;
	    switch (difficulty) {
		    case 1:
			    gameState.GameDifficulty = 1f;
			    break;
		    case 2:
			    gameState.GameDifficulty = 0.5f;
			    break;
		    case 3:
			    gameState.GameDifficulty = 2f;
			    break;
		    default:
			    gameState.GameDifficulty = 1f;
			    break;
	    }
    }
    
    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
       
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Screen.fullScreen = false;
        }
    }
}
