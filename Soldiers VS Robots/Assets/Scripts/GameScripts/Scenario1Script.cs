using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario1Script : MonoBehaviour
{
    [SerializeField] private GameState missionTime;
    
    void Start()
    {
        missionTime.MissionTime = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        missionTime.MissionTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Screen.fullScreen = false;
        }
    }
}
