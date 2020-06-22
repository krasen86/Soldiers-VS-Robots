using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoventScript : MonoBehaviour
{

	[SerializeField] private float speed;
    private Rigidbody2D playerBody;
	private Vector3 movement;
	private Animator playerAnimator;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();
    }

    void Update(){

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

	private void MovePlayer()
	{
		playerBody.MovePosition(transform.position + movement * speed * Time.deltaTime);	
	}
}
