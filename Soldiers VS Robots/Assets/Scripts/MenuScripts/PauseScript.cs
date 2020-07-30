using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public static bool Paused { get; set; }

    [SerializeField] private GameObject pausedPanel;
    // Start is called before the first frame update
    void Start()
    {
        Paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }

    private void PauseGame()
    {
        pausedPanel.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void ResumeGame()
    {
        pausedPanel.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
    
    public void QuitGame()
    {
        PlayerState playerState = PlayerState.Instance;
        DataIOStream.AddPlayer(playerState.PlayerName, playerState.PlayerScore);
        Paused = false;
        Application.Quit();
    }
    
}
