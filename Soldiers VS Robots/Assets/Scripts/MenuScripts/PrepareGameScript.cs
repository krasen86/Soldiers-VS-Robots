using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PrepareGameScript : MonoBehaviour
{
    public void SelectScenario() {
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
}
