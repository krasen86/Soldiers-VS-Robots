using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioSelectionScript : MonoBehaviour
{
    public void StartGameEngland() {
        SceneManager.LoadScene("EnglandGame");
    }
    public void StartGameScotland() {
        SceneManager.LoadScene("ScotlandGame");
    }
    public void BackToPrepareGame() {
        SceneManager.LoadScene("PrepareGame");
    }
}
