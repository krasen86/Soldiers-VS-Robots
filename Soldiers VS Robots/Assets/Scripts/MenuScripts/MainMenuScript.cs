using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{


    void Awake()
    {
        DataIOStream.LoadPlayers();
    }

    public void StartNewGame() 
    {
        SceneManager.LoadScene("PrepareGame");
    }

    public void Update() 
    {
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
