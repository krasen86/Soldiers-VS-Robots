using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class PrepareGameScript : MonoBehaviour
{
	[SerializeField] private TMP_InputField playerName;
	[SerializeField] private PlayerState playerState;
	[SerializeField] private GameState gameState;



	
    public void SelectScenario()
    {
	    playerState = PlayerState.Instance;
	    //User name can be max 50 charecters, name canot be empty and must contain leters(english latin) and/or number, underscore is allowed 
		if(string.IsNullOrEmpty(playerName.text) || !Regex.IsMatch(playerName.text,  @"^[a-zA-Z0-9_]+[a-zA-Z0-9_ ]*$") || playerName.text.Length >= 50)
		{
			ClearInputField();
		}
		else
		{		
			playerState.PlayerName = playerName.text;
			SceneManager.LoadScene(GameConstants.sceneScenarioSelection);
			//if not initialized dificulty is normal
			if (gameState.GameDifficulty <= 0)
			{
				gameState.GameDifficulty = GameConstants.normalDificulty;
			}

		}

    }

    private void ClearInputField()
    {
	    playerName.text = "";
	    playerName.placeholder.GetComponent<TMP_Text>().text = GameConstants.invalidNameMsg;
    }

    public void SetGameDifficulty(int difficulty)
    {
	    
	    switch (difficulty) 
	    {
		    case 0:
			    gameState.GameDifficulty = GameConstants.normalDificulty;
			    break;
		    case 1:
			    gameState.GameDifficulty = GameConstants.easyDificulty;
			    break;
		    case 2:
			    gameState.GameDifficulty = GameConstants.hardDificulty;
			    break;
	    }
    }

    public void BackToMainMenu() 
    {
        SceneManager.LoadScene(GameConstants.sceneMain);
    }
       
    public void Update() 
    {
	    if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Screen.fullScreen = false;
        }
    }

    void Start()
    {
	    gameState = GameState.Instance;
	    playerState = PlayerState.Instance;
    }
}
