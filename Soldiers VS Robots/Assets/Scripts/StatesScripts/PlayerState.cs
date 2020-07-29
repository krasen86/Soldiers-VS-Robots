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
 	public bool PlayerDead { get; set;}
    public bool ItemInRange { get; set; }


    public void SetPlayerState()
    {
        PlayerHealth = GameConstants.startHealth;
        PlayerScore = 0;
		if(GameState.Instance.GameDifficulty == GameConstants.hardDificulty)
		{
			PlayerBullets = GameConstants.startBulletsHard;
		}
		else
		{
			PlayerBullets = (int) (GameConstants.startBullets/GameState.Instance.GameDifficulty);
		}
       
		PlayerDead = false;
    }

}
