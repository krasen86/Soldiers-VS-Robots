using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RobotScript : MonoBehaviour
{

    public int HealthPoints { get; set; }
    public int Damage { get; set; }

    public float MovementSpeed { get; set; }
    
    public Rigidbody2D RobotBody { get; set; }


    [SerializeField] private float atackDistance;
    [SerializeField] private float followDistance;
	[SerializeField] private GameObject laserTemplate;
	[SerializeField] private Slider healthBar;
	[SerializeField] private Image healthBarImage;
	[SerializeField] private GameObject soldier;
	[SerializeField] private GameObject deathRobot;
    
    [SerializeField] private Boundary boundary; 
    [SerializeField] private Vector2 startPosition;   

	public float SoldierPosition { get; set; }
	public GameState GameState { get; set; }
	public Animator RobotAnimator { get; set; }
	public float FireDelay { get; set; }
	public bool CanFire { get; set; }


    public Vector2 GetStartPosition()
    {
        return startPosition;
    }


    // Start is called before the first frame update
    void Start()
    {
     	SoldierPosition = soldier.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(RobotBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(RobotBody.position.y, boundary.yMin, boundary.yMax), transform.position.z
        );
        
    }

	public GameObject GetSoldier()
	{
		return soldier;
	}

	public float GetFollowDistance()
	{ 
		return followDistance;
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

	public void KillRobot()
	{
		GameObject deathAnimation = Instantiate(deathRobot, transform.position, Quaternion.identity );
		Destroy(deathAnimation, 1f);
	}

	public void FireLaser()
	{
		Vector3 direction =  soldier.transform.position - transform.position;
		EnemyLaser laser = Instantiate(laserTemplate, transform.position, Quaternion.identity).GetComponent<EnemyLaser>();
		float tempZ = Mathf.Atan2(RobotAnimator.GetFloat("moveY"), RobotAnimator.GetFloat("moveX")) * Mathf.Rad2Deg;

		laser.FireLaser(direction, new Vector3(0,0, tempZ));
	}

	   
	public IEnumerator Delay()
   {
     yield return new WaitForSeconds(this.FireDelay);
     this.CanFire = true;
   }


    public void FindSoldier()
    {
        if (Vector3.Distance(soldier.transform.position, transform.position) < followDistance && 
            Vector3.Distance(soldier.transform.position, transform.position) > atackDistance)
        {
			RobotAnimator.enabled = true;
            this.RobotBody.MovePosition(Vector3.MoveTowards(transform.position, soldier.transform.position, this.MovementSpeed * Time.deltaTime));
			Vector3 movement = soldier.transform.position - transform.position;
			RobotAnimator.SetFloat("moveX", movement.x);            		
			RobotAnimator.SetFloat("moveY", movement.y);	
			RobotAnimator.SetBool("moving", true);
        }
		else 
		{
			RobotAnimator.enabled = false;
		}

    }

    public void SetHealthBar(int health)
	{
		healthBar.maxValue = health;
	}
}
