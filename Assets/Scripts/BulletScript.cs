using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletScript : MonoBehaviour
{
    private float spped = 5f;

    public delegate void Healthattack();

    public event Healthattack attackEvent;

    private IObjectPool<BulletScript> bpool;

    private Transform bulletTransform;

    public void SetPool(IObjectPool<BulletScript> pool)
    {
        bpool = pool;
    }
    void Start()
    {
        
        
    }
    private void OnEnable()
    {
        Invoke("Distrybullet", 5f);
    }

    public void SetDirection(Transform dir)
    {
        bulletTransform = dir;
    }
    void Update()
    {
       transform.Translate(transform.forward * spped * Time.deltaTime);    
    }
    void Distrybullet()
    {
        bpool.Release(this);
        //gameObject.SetActive(false);
      //  Destroy(gameObject);
    }

}
