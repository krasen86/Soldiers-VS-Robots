using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlueRobotScript : RobotScript
{
    
    [SerializeField] private float blueAtackDistance;
    [SerializeField] private float blueFollowDistance;
    [SerializeField] private Transform blueStartPosition;
	[SerializeField] private GameObject laserTemplate;
	[SerializeField] private Slider healthBar;
	[SerializeField] private Image healthBarImage;
	[SerializeField] private GameObject soldier;
	private float soldierPosition;
	private PlayerState playerState;
	private GameState gameState;
	private Animator blueRobotAnimator;
	public float FireDelay { get; set; }
	public bool CanFire { get; set; }

    void Awake()
    {  
	    playerState = PlayerState.Instance;
        HealthPoints = 100;
	    gameState = GameState.Instance;
	    this.Damage = 10;
	    this.MovementSpeed = 2f;
      	FireDelay = 0.75f;
		CanFire = true;
    }

    void Start()
    {
	  
	    soldierPosition = soldier.transform.position.y;
        blueRobotAnimator = GetComponent<Animator>();

    }

    void Update()
    {
		Debug.Log(this.HealthPoints);
		healthBar.value = this.HealthPoints;
	    if (healthBar.value <= healthBar.minValue)
	    {
		    healthBarImage.enabled = false;
	    }
	    if (healthBar.value > healthBar.minValue && !healthBarImage.enabled)
	    {
		    healthBarImage.enabled = true;
	    }

		if(Vector3.Distance(soldier.transform.position, transform.position) < blueFollowDistance)
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
			blueRobotAnimator.SetBool("moving", false);
		}

        FindSoldier();
    }

	void FireLaser()
	{
		Vector3 direction =  soldier.transform.position - transform.position;
		EnemyLaser laser = Instantiate(laserTemplate, transform.position, Quaternion.identity).GetComponent<EnemyLaser>();

		laser.FireLaser(direction, Vector3.zero);
	}
	   
	IEnumerator Delay()
   {
     yield return new WaitForSeconds(this.FireDelay);
     this.CanFire = true;
   }


    private void FindSoldier()
    {
        if (Vector3.Distance(soldier.transform.position, transform.position) < blueFollowDistance && 
            Vector3.Distance(soldier.transform.position, transform.position) > blueAtackDistance)
        {
			blueRobotAnimator.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, soldier.transform.position, this.MovementSpeed * Time.deltaTime);
            Vector3 movement = soldier.transform.position - transform.position;
			blueRobotAnimator.SetFloat("moveX", movement.x);            		
			blueRobotAnimator.SetFloat("moveY", movement.y);	
			blueRobotAnimator.SetBool("moving", true);

        }
		else 
		{
			blueRobotAnimator.enabled = false;
		}

    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag.Equals("bullet"))
		{
			playerState.PlayerScore += (int) (this.Damage * gameState.GameDifficulty);
			this.HealthPoints -= this.Damage;
			Debug.Log(this.HealthPoints);
		}	
	}
}
