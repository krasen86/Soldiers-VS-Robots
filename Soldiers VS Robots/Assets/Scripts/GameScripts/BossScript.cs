using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : RobotScript
{
    

    // Start is called before the first frame update
    void Start()
    {
        this.GameState = GameState.Instance;
        this.HealthPoints = (int) ((GameConstants.startHealth * GameConstants.bossModifier )* this.GameState.GameDifficulty);
        SetHealthBar(this.HealthPoints);
        this.Damage = GameConstants.bossModifier * GameConstants.baseDamage;
        FireDelay = GameConstants.robotFireDelay;
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
        if(collision.gameObject.tag == GameConstants.bulletTag )
        {		
            PlayerState playerState = PlayerState.Instance;
            playerState.PlayerScore += (int) (this.Damage * this.GameState.GameDifficulty);
            this.HealthPoints -= (int) (this.Damage/GameConstants.bossModifier);
            Destroy(collision.gameObject);
        }	
    }
}
