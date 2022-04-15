using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float spped = 5f;

    public delegate void Healthattack();

    public event Healthattack attackEvent;

    void Start()
    {
        
        
    }
    private void OnEnable()
    {
        Invoke("Distrybullet", 5f);
    }

    void Update()
    {
        transform.Translate(transform.forward * spped * Time.deltaTime);    
    }
    void Distrybullet()
    {
        gameObject.SetActive(false);
      //  Destroy(gameObject);
    }

}
