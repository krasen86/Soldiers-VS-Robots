using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class GameOverScript : MonoBehaviour
{
    private PlayerState playerState;
    [SerializeField] private TMP_Text playerScore;
    private GameState gameState;

    
    // Start is called before the first frame update
    void Start()
    {
        DataIOStream.SavePlayers();
        gameState = GameState.Instance;
        playerState = PlayerState.Instance;
        playerScore.text = "Score: " + playerState.PlayerScore;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("ScenarioSelection");
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
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Has quit Game");
    }
}
