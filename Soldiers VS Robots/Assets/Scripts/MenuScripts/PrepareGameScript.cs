using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PrepareGameScript : MonoBehaviour
{
	[SerializeField] private TMP_InputField playerName;
	
    public void SelectScenario() {
		if(playerName.text == null && playerName.text == "")
		{
			playerName.placeholder.GetComponent<TMP_Text>().text = "Error";
		}
		else
		{		
			Player player = new Player();
         	player.SetPlayerName(playerName.text);
            SceneManager.LoadScene("ScenarioSelection");
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
