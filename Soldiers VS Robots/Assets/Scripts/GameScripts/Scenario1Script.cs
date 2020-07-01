using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario1Script : MonoBehaviour
{
    private GameState gameState;

    void Awake()
    {
        gameState = GameState.Instance;
    }

    void Start()
    {
        gameState.MissionTime = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        gameState.MissionTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Screen.fullScreen = false;
        }
    }
}
