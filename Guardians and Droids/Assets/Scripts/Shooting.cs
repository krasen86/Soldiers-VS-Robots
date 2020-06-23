using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletTemplate;

    [SerializeField] private Transform weapon;

    [SerializeField] private float fireForce = 50f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletTemplate, weapon.position, Quaternion.identity);
        Rigidbody2D body2D = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y);
        body2D.AddForce(transform.up * fireForce, ForceMode2D.Impulse );
    }
}
