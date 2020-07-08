using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject robotBlue;
    [SerializeField] private GameObject robotGreen;

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
        if (collision.gameObject.tag == "enemyBlue")
        {
            GameObject deathAnimation = Instantiate(robotBlue, transform.position, Quaternion.identity );
            Destroy(this.gameObject);
            Destroy(deathAnimation, 0.2f);
        }
        else if (collision.gameObject.tag == "enemyGreen")
        {
            GameObject deathAnimation = Instantiate(robotGreen, transform.position, Quaternion.identity );
            Destroy(this.gameObject);
            Destroy(deathAnimation, 0.2f);
        }
        else
        {
            Destroy(this.gameObject);

        }
    }
    

}
