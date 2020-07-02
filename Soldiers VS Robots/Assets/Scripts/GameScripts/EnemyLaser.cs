﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        Destroy(this.gameObject);
    }
    
}
