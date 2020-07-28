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

    public void SetPlayerState()
    {
        PlayerHealth = 100;
        PlayerScore = 0;
		if(GameState.Instance.GameDifficulty == 2)
		{
			PlayerBullets = 80;
		}
		else
		{
			PlayerBullets = (int) (60/GameState.Instance.GameDifficulty);
		}
       
		PlayerDead = false;
    }

}
