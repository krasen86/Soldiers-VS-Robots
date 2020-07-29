using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionScript : MonoBehaviour
{
    private GameState gameState;

    void Awake()
    {
        gameState = GameState.Instance;
        

    }

    void Start()
    {
        gameState.MissionTime = GameConstants.defaultMisionTime;
    }

    // Update is called once per frame
    void Update()
    {
        gameState.MissionTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = false;
        }
    }
}
