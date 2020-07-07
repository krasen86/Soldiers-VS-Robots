using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : RobotScript
{
    
    private PlayerState playerState;
    // Start is called before the first frame update
    void Start()
    {
        this.GameState = GameState.Instance;
        playerState = PlayerState.Instance;
        this.HealthPoints = (int) (200 * this.GameState.GameDifficulty);
        SetHealthBar(this.HealthPoints);
        this.Damage = 20;
        this.MovementSpeed = 5f;
        FireDelay = 0.75f;
        CanFire = true;
        this.RobotBody = GetComponent<Rigidbody2D>(); 
        this.RobotAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
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
                if(this.CanFire)
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
                this.HealthPoints -= (int) (this.Damage * this.GameState.GameDifficulty);
            }
            else if (this.GameState.GameDifficulty == 2)
            {
                this.HealthPoints -= (int) (this.Damage * 0.5);
            }
            else
            {
                this.HealthPoints -= (int) (this.Damage * 2);
            }
            Destroy(collision.gameObject);
        }	
    }
}
