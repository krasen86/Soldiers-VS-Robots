using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartNewGame() {
        SceneManager.LoadScene("CreatePlayer");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Has quit Game");
    }
}
