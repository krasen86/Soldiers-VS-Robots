using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotScript : MonoBehaviour
{

    public int HealthPoints { get; set; }
    public int Damage { get; set; }

    public float MovementSpeed { get; set; }
    
    private Rigidbody2D robotBody;



    
    [SerializeField] private Boundary boundary;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.Clamp(robotBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(robotBody.position.y, boundary.yMin, boundary.yMax), transform.position.z
        );
		if(this.HealthPoints <= 0)
		{
			Destroy(this.gameObject);	
		}
        
    }
    

}
