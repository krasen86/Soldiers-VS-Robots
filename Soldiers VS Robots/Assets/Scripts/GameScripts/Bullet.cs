﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject robotBlue;
    [SerializeField] private GameObject robotGreen;
 	[SerializeField] private AudioSource hitAudio;

    private Rigidbody2D rigidBody;

    void Awake()
    {
         rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    public void FireBullet(Vector2 velocity, Vector3 rotate)
    {
        rigidBody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(rotate);
    }

    void  OnCollisionEnter2D (Collision2D collision)
    {
		hitAudio.Play();
        if (collision.gameObject.tag == "enemyBlue")
        {
            GameObject damageAnimation = Instantiate(robotBlue, transform.position, Quaternion.identity );
            Destroy(this.gameObject);
            Destroy(damageAnimation, 0.2f);
        }
        else if (collision.gameObject.tag == "enemyGreen")
        {
            GameObject damageAnimation = Instantiate(robotGreen, transform.position, Quaternion.identity );
            Destroy(this.gameObject);
            Destroy(damageAnimation, 0.2f);
        }
        else
        {
            Destroy(this.gameObject);

        }
    }
    

}
