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
        // transform.Translate(transform.up*Time.deltaTime);


        Vector3 direction = target.position - transform.position;

        direction.y = 0;
    
        Quaternion lookRotaion=Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotaion, 0.5f);


       // transform.position=Vector3.MoveTowards(transform.position, new Vector3(target.position.x,transform.position.y,target.position.z),movespeed*Time.deltaTime);
        
       // transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
        
      //  MoveDirection();

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
