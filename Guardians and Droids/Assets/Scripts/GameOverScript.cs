using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartNewGame() {
        SceneManager.LoadScene("ScenarioSelection");
    }
    
    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Screen.fullScreen = false;
        }
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Has quit Game");
    }
}
