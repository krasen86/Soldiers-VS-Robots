using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlueRobotScript : RobotScript
{
    


    void Awake()
    {  	    
		this.GameState = GameState.Instance;
        HealthPoints = GameConstants.startHealth;
	    this.Damage = GameConstants.baseDamage;
      	FireDelay = GameConstants.robotFireDelay;
		CanFire = true;
	 	this.RobotBody = GetComponent<Rigidbody2D>(); 
        this.RobotAnimator = GetComponent<Animator>();
    }


    void Update()
    {
		if(HealthPoints <= 0)
		{	
			KillRobot();
			Destroy(this.gameObject);
		}
		else if(HealthPoints > 0)
		{
			//The robot is restricted in movemnet within predifined boundries
			ControllBoundries();

			//Check if player is in rannge and fire laser
			CheckForAttackSoldier();
			//Find and follow soldier
			FollowSoldier();
		}

		UpdateHealthBar();

    }







	void OnCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag == GameConstants.bulletTag)
		{			
			PlayerState playerState = PlayerState.Instance;
			playerState.PlayerScore += (int) (this.Damage * this.GameState.GameDifficulty);
			if(this.GameState.GameDifficulty == GameConstants.normalDificulty)
			{
				this.HealthPoints -= this.Damage ;
			}
			else if (this.GameState.GameDifficulty == GameConstants.hardDificulty)
			{
				this.HealthPoints -= (int) (this.Damage * GameConstants.easyDificulty);//Recive less damage
			}
			else
			{
				this.HealthPoints -= (int) (this.Damage * GameConstants.hardDificulty);//Receive more damage for easy gameplay
			}
			Destroy(collision.gameObject);
		}	
	}

}
