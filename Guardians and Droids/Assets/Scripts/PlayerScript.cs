using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

	[SerializeField] private float speed;
    private Rigidbody2D playerBody;
	private Vector3 movement;
	private Animator playerAnimator;
	[SerializeField] private GameObject bulletTemplate;
	
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();
    }

    void Update(){
		if(Input.GetButtonDown("Shoot"))
        {   
	        Shoot();
        	StartCoroutine(ShootCo());
         
        }
	}
    void FixedUpdate()
    {
		movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

		if(movement != Vector3.zero)
		{
			MovePlayer();		
			playerAnimator.SetFloat("moveX", movement.x);            		
			playerAnimator.SetFloat("moveY", movement.y);	
			playerAnimator.SetBool("running", true);		
		}
		else
		{
			playerAnimator.SetBool("running", false);		
		}

	
    }

	private IEnumerator ShootCo()
	{
		playerAnimator.SetBool("shooting", true);
		yield return null;
		playerAnimator.SetBool("shooting", false);
		yield return new WaitForSeconds(.1f);
	}

	void Shoot()
	{
		Vector2 direction = new Vector2(playerAnimator.GetFloat("moveX"),playerAnimator.GetFloat("moveY"));
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

	private void MovePlayer()
	{
		playerBody.MovePosition(transform.position + movement * speed * Time.deltaTime);	
	}
}
