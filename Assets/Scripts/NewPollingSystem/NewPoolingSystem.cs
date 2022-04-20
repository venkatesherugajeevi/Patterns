using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NewPoolingSystem : MonoBehaviour
{
    public BulletScript bulletPrefab;
    public Transform shootPosiotion;
    public IObjectPool<BulletScript> n_bulletPool;

    private void Awake()
    {
        n_bulletPool = new ObjectPool<BulletScript>(CreateBullet,Onget,OnRelease);
    }

    public BulletScript CreateBullet()
    {
       BulletScript bullet= Instantiate(bulletPrefab,shootPosiotion.position,Quaternion.identity);
        bullet.transform.parent = transform;
        bullet.SetPool(n_bulletPool);
        return bullet;
    }
    public void Onget(BulletScript bullet)
    {
        bullet.transform.position = shootPosiotion.position;
        bullet.gameObject.SetActive(true);
    }
    public void OnRelease(BulletScript bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            n_bulletPool.Get();
        }
    }
}
