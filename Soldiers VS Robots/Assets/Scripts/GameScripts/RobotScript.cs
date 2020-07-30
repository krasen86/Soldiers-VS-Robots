using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RobotScript : MonoBehaviour
{


    
    [SerializeField] private float atackDistance;
    [SerializeField] private float followDistance;
	[SerializeField] private GameObject laserTemplate;
	[SerializeField] private Slider healthBar;
	[SerializeField] private Image healthBarImage;
	[SerializeField] private GameObject soldier;
	[SerializeField] private GameObject deathRobot;
    [SerializeField] private Boundary boundary; 
    [SerializeField] private Vector2 startPosition;   
    [SerializeField] private float movementSpeed;

	protected GameState GameState { get; set; }
	protected Animator RobotAnimator { get; set; }
	protected float FireDelay { get; set; }
	protected bool CanFire { get; set; }
    protected int HealthPoints { get; set; }
    protected int Damage { get; set; }
    protected Rigidbody2D RobotBody { get; set; }
	

 
    public Vector3 GetStartPosition()
    {
        return new Vector3(startPosition.x, startPosition.y, 0f);
    }

    public void UpdateHealthBar()
	{		
		healthBar.value = HealthPoints;
        if (healthBar.value <= healthBar.minValue)
        {
        	healthBarImage.enabled = false;
        }
        if (healthBar.value > healthBar.minValue && !healthBarImage.enabled)
        {
        	healthBarImage.enabled = true;
        }
	}

	public void CheckForAttackSoldier()
	{
		PlayerState playerState = PlayerState.Instance;

		if(Vector3.Distance(soldier.transform.position, transform.position) < followDistance)
		{     
			if(CanFire && !playerState.PlayerDead)
			{
				FireLaser();
				CanFire = false;
				StartCoroutine(Delay());
			}
		}
		else
		{
			//Teleport to start position if player not in range
			if (transform.position != GetStartPosition())
			{
				transform.position = GetStartPosition();
				RobotAnimator.SetBool(GameConstants.movementAnim, false);
			}

		}
	}

	public void ControllBoundries()
	{
		transform.position = new Vector3(Mathf.Clamp(RobotBody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(RobotBody.position.y, boundary.yMin, boundary.yMax), transform.position.z
		);
	}

	public void KillRobot()
	{
		GameObject deathAnimation = Instantiate(deathRobot, transform.position, Quaternion.identity );
		Destroy(deathAnimation, GameConstants.deathAnimationDelay);
	}

	public void FireLaser()
	{
		Vector3 direction =  soldier.transform.position - transform.position;
		LaserScript laser = Instantiate(laserTemplate, transform.position, Quaternion.identity).GetComponent<LaserScript>();
		float vectorZValue = Mathf.Atan2(RobotAnimator.GetFloat(GameConstants.moveYAnim), RobotAnimator.GetFloat(GameConstants.moveXAnim)) * Mathf.Rad2Deg;
		laser.FireLaser(direction, new Vector3(0,0, vectorZValue));
	}

	   
	public IEnumerator Delay()
   {
     yield return new WaitForSeconds(this.FireDelay);
     this.CanFire = true;
   }


    public void FollowSoldier()
    {
	    //if soldier is in follow range and not less then minimum atack distnace move robot towards soldier
        if (Vector3.Distance(soldier.transform.position, transform.position) < followDistance && 
            Vector3.Distance(soldier.transform.position, transform.position) > atackDistance)
        {
			RobotAnimator.enabled = true;
            this.RobotBody.MovePosition(Vector3.MoveTowards(transform.position, soldier.transform.position, movementSpeed * Time.deltaTime));
			Vector3 movement = soldier.transform.position - transform.position;
			RobotAnimator.SetFloat(GameConstants.moveXAnim, movement.x);            		
			RobotAnimator.SetFloat(GameConstants.moveYAnim, movement.y);	
			RobotAnimator.SetBool(GameConstants.movementAnim, true);
        }
		else 
		{
			RobotAnimator.enabled = false; // stop animation so that it doesn't loop moving when close to soldier
		}

    }

    public void SetHealthBar(int health)
	{
		healthBar.maxValue = health;
	}
    
}
