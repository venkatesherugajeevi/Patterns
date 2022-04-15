using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform target;
    public float RotationSpeed = 40;
    public float movespeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        MoveDirection();
      
    }
    void MoveDirection()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
      
        if (direction.magnitude > 2)
        {
            direction = direction.normalized;
            transform.Translate(transform.forward * movespeed * Time.deltaTime);
            Quaternion lookangle = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookangle, RotationSpeed * Time.deltaTime);
        }
    }
    }
