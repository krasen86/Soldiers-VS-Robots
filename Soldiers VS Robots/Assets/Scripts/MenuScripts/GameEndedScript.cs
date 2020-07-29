using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEndedScript : MonoBehaviour
{
    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverMessage;

    public static bool Completed { get; set; }
    private GameState gameState;
    private PlayerState playerState;
    
    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerState.Instance;
        gameState = GameState.Instance;
        Completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.MissionTime <= 0)
        {
            gameOverPanel.SetActive(true);
            gameOverMessage.text = GameConstants.gameCompletedTimeOver;
            StartCoroutine(DelayAndEnd());
        }
        else if (playerState.PlayerHealth <= 0)
        {
            gameOverPanel.SetActive(true);
            gameOverMessage.text = GameConstants.gameCompletedKilled;
            StartCoroutine(DelayAndEnd());
        }
        else if (Completed)
        {
            gameOverPanel.SetActive(true);
            gameOverMessage.text = GameConstants.gameCompletedSuccess;
            StartCoroutine(DelayAndEnd());
        }
        else
        { 
            gameOverPanel.SetActive(false);

        }
    }
    
    private IEnumerator DelayAndEnd()
    {
        yield return new WaitForSeconds(GameConstants.baseDelay);
		DataIOStream.AddPlayer(playerState.PlayerName, playerState.PlayerScore);
        SceneManager.LoadScene(GameConstants.sceneGameOver);
    }
}
