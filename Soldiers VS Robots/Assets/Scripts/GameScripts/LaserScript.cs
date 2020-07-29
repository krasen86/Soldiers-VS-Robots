using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private GameObject damage;
    [SerializeField] private AudioSource hitAudio;
    

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, GameConstants.baseDelay);

    }
    
    public void FireLaser(Vector3 velocity, Vector3 rotate)
    {
        rigidBody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(rotate);
    }
    
    void OnCollisionEnter2D (Collision2D collision)
    {
        hitAudio.Play();
        if (collision.gameObject.tag == GameConstants.playerTag)
        {	
            GameObject damageAnimation = Instantiate(damage, collision.gameObject.transform.position , Quaternion.identity );
            Destroy(this.gameObject);
            Destroy(damageAnimation, GameConstants.shortDelay);
        }
        else
        {
            Destroy(this.gameObject);

        }
    }
    
}
