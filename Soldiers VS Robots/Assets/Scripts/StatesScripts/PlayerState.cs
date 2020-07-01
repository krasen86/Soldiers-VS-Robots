using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="PlayerState", menuName="States/PlayerState")]
public class PlayerState : SingletonScriptableObject<PlayerState>
{
    public string PlayerName { get; set;}
    public int PlayerHealth { get; set;}
    public int PlayerScore { get; set;}
    public int PlayerBullets { get; set;}

    public void SetPlayerState()
    {
        PlayerHealth = 100;
        PlayerScore = 0;
        PlayerBullets = 100;
    }

}
