using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
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
        Destroy(this.gameObject);
    }
    

}
