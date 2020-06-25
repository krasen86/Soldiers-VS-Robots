using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRobotScript : RobotScript
{
    
    [SerializeField] private float blueAtackDistance;
    [SerializeField] private float blueFollowDistance;

    [SerializeField] private Transform blueStartPosition;
    private Animator blueRobotAnimator;
	[SerializeField] private GameObject laserTemplate;
	private float soldierPosition;


    // Start is called before the first frame update
    void Start()
    {
		soldierPosition = GetSoldier().transform.position.y;
        blueRobotAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
		

		if(Vector3.Distance(GetSoldier().transform.position, transform.position) < blueFollowDistance)
		{   
			RotateRobot();        
			FireLaser();
		}
		
		
        FindSoldier();
    }

	void FireLaser()
	{
		Vector3 direction =  GetSoldier().transform.position - transform.position;
		EnemyLaser laser = Instantiate(laserTemplate, transform.position, Quaternion.identity).GetComponent<EnemyLaser>();

		laser.FireLaser(direction, Vector3.zero);
	}
	
	private void RotateRobot(){
			if( GetSoldier().transform.position.x >= soldierPosition  && transform.position.x >= soldierPosition)
			{
				blueRobotAnimator.SetBool("left", false);
				blueRobotAnimator.SetBool("right", true);
			
				soldierPosition = GetSoldier().transform.position.x;
			}
			else if( GetSoldier().transform.position.x <= soldierPosition &&  transform.position.x <= soldierPosition)
			{
				blueRobotAnimator.SetBool("right", false);
				blueRobotAnimator.SetBool("left", true);				
				soldierPosition = GetSoldier().transform.position.x;
			}
	}

    private void FindSoldier()
    {
        if (Vector3.Distance(GetSoldier().transform.position, transform.position) < blueFollowDistance && 
            Vector3.Distance(GetSoldier().transform.position, transform.position) > blueAtackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, GetSoldier().transform.position, GetMovementSpeed() * Time.deltaTime);
            
	
        }

    }
}
