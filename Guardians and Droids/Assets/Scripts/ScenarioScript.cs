using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioScript : MonoBehaviour
{
    public void StartGameEngland() {
        SceneManager.LoadScene("EnglandGame");
    }
    public void StartGameEgipt() {
        SceneManager.LoadScene("EgiptGame");
    }
    public void BackToPrepareGame() {
        SceneManager.LoadScene("PrepareGame");
    }
}
