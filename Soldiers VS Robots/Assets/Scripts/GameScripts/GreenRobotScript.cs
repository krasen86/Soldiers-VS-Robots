using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenRobotScript  : RobotScript
{
      
	private PlayerState playerState;


    void Awake()
    {  	    
		this.GameState = GameState.Instance;
	    playerState = PlayerState.Instance;
        HealthPoints = 100;
	    this.Damage = 10;
	    this.MovementSpeed = 4f;
      	FireDelay = 0.75f;
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

		else if(HealthPoints > 0){
		

			if(Vector3.Distance(GetSoldier().transform.position, transform.position) < GetFollowDistance())
			{     
				if(this.CanFire  && !playerState.PlayerDead)
				{
					FireLaser();
					this.CanFire = false;
					StartCoroutine(Delay());
				}
			}
			else 
			{
				this.RobotBody.MovePosition(Vector3.MoveTowards(transform.position, this.GetStartPosition(), this.MovementSpeed * Time.deltaTime));
				RobotAnimator.SetBool("moving", false);
			}

       		FindSoldier();
		}

		UpdateHealthBar();



    }






	void OnCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag == "bullet" )
		{			
			playerState.PlayerScore += (int) (this.Damage * this.GameState.GameDifficulty);
			if(this.GameState.GameDifficulty == 1)
			{
				this.HealthPoints -= this.Damage  * 2;
			}
			else if (this.GameState.GameDifficulty == 2)
			{
				this.HealthPoints -= (int) (this.Damage * 0.5) * 2;
			}
			else
			{
				this.HealthPoints -= (int) (this.Damage * 2) * 2;
			}
			Destroy(collision.gameObject);
		}	
	}
}
