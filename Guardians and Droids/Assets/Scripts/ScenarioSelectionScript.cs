using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioSelectionScript : MonoBehaviour
{
    public void StartMission1() {
        SceneManager.LoadScene("Mission1");
    }
    public void StartMission2() {
        SceneManager.LoadScene("Mission2");
    }
    public void BackToPrepareGame() {
        SceneManager.LoadScene("PrepareGame");
    }
}
