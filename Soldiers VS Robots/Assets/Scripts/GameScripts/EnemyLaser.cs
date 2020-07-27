using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private GameObject damage;
    [SerializeField] private AudioSource hitAudio;
    

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3f);

    }
    
    public void FireLaser(Vector3 velocity, Vector3 rotate)
    {
        rigidBody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(rotate);
    }
    
    void OnCollisionEnter2D (Collision2D collision)
    {
        hitAudio.Play();
        if (collision.gameObject.tag == "Player")
        {	
            GameObject damageAnimation = Instantiate(damage, collision.gameObject.transform.position , Quaternion.identity );
            Destroy(this.gameObject);
            Destroy(damageAnimation, 0.1f);
        }
        else
        {
            Destroy(this.gameObject);

        }
    }
    
}
