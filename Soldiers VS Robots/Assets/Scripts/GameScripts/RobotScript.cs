using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{

    [SerializeField] private int healthPoints;
    [SerializeField] private int damage;

    [SerializeField] private string robotType;
    
    [SerializeField] private float movementSpeed;

    [SerializeField] private GameObject soldier;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetSoldier()
    {
        return this.soldier;
    }

    public float GetMovementSpeed()
    {
        return this.movementSpeed;
    }
}
