using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{

	[SerializeField] private float soldierSpeed;
    private Rigidbody2D soldierBody;
	private Vector3 movement;
	private Animator soldierAnimator;
	[SerializeField] private GameObject bulletTemplate;
	private PlayerState playerState;
	private GameState gameState;
	[SerializeField] private Boundary boundary;
	
    void Start()
    {
		gameState = GameState.Instance;
	    playerState = PlayerState.Instance;
	    soldierBody = GetComponent<Rigidbody2D>();
        soldierAnimator = GetComponent<Animator>();
    }

    void Update(){
		if(Input.GetButtonDown("Shoot") && playerState.PlayerBullets > 0)
        {
	        FireBullet();
        	StartCoroutine(FireCo());
        }
		transform.position = new Vector3(Mathf.Clamp(soldierBody.position.x, boundary.xMin, boundary.xMax),
											Mathf.Clamp(soldierBody.position.y, boundary.yMin, boundary.yMax), transform.position.z
											);
	}
    void FixedUpdate()
    {
		movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

		if(movement != Vector3.zero)
		{
			MoveSoldier();		
			soldierAnimator.SetFloat("moveX", movement.x);            		
			soldierAnimator.SetFloat("moveY", movement.y);	
			soldierAnimator.SetBool("running", true);		
		}
		else
		{
			soldierAnimator.SetBool("running", false);		
		}

	
    }

	private IEnumerator FireCo()
	{
		soldierAnimator.SetBool("shooting", true);
		yield return null;
		soldierAnimator.SetBool("shooting", false);
		yield return new WaitForSeconds(.1f);
	}

	void FireBullet()
	{
		playerState.PlayerBullets = playerState.PlayerBullets - 1;
		Vector2 direction = new Vector2(soldierAnimator.GetFloat("moveX"),soldierAnimator.GetFloat("moveY"));
		Bullet bullet = Instantiate(bulletTemplate, transform.position, Quaternion.identity).GetComponent<Bullet>();
		if (direction.x == 0 && direction.y == 0)
		{
			bullet.FireBullet(Vector2.right, Vector3.zero);

		}
		else
		{
			bullet.FireBullet(direction, Vector3.zero);

		}

	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag == "laser" )
		{			
			playerState.PlayerHealth -= (int) (10 * gameState.GameDifficulty);
		}	
	}

	private void MoveSoldier()
	{
		soldierBody.MovePosition(transform.position + movement * soldierSpeed * Time.deltaTime);	

	}

}
[System.Serializable]
public class Boundary {
		
	public float xMin;
	public float yMin;
	public float yMax;
	public float xMax;

}
