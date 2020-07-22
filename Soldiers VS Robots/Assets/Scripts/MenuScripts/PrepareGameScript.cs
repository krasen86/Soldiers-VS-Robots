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
		if(string.IsNullOrEmpty(playerName.text) || !Regex.IsMatch(playerName.text,  @"^[a-zA-Z0-9_]+[a-zA-Z0-9_ ]*$") || playerName.text.Length >= 50)
		{
			ClearInputField();
		}
		else
		{		
			playerState.PlayerName = playerName.text;
			SceneManager.LoadScene("ScenarioSelection");
			if (gameState.GameDifficulty <= 0)
			{
				gameState.GameDifficulty = 1f;
			}

		}

    }

    private void ClearInputField()
    {
	    playerName.text = "";
	    playerName.placeholder.GetComponent<TMP_Text>().text = "Invalid Name";
    }

    public void SetGameDifficulty(int difficulty)
    {
	    
	    switch (difficulty) 
	    {
		    case 0:
			    gameState.GameDifficulty = 1f;
			    break;
		    case 1:
			    gameState.GameDifficulty = 0.5f;
			    break;
		    case 2:
			    gameState.GameDifficulty = 2f;
			    break;
	    }
    }

    public void BackToMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
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
