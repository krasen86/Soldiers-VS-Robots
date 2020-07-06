using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerScoreScript : MonoBehaviour
{
    [SerializeField] private TMP_Text  playerRank;
    [SerializeField] private TMP_Text  playerName;

    [SerializeField] private TMP_Text  playerScore;

    void Start()
    {

    }

    public void SetPlayerName(string name)
    {
        playerName.text = name;
    }
    public void SetPlayerScore(string score)
    {
        playerScore.text = score;
    }
    public void SetPlayerRank(string rank)
    {
        playerRank.text = rank;
    }
}
