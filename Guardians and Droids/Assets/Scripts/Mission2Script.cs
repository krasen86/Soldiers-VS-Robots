﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission2Script : MonoBehaviour
{
    public void GameEnded() {
        SceneManager.LoadScene("GameEnded");
    }
}