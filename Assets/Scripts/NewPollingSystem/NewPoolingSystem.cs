using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NewPoolingSystem : MonoBehaviour
{
    public BulletScript bulletPrefab;
    public Transform shootPosiotion;
    public IObjectPool<BulletScript> n_bulletPool;
    public Transform Player;

    private void Awake()
    {
        n_bulletPool = new ObjectPool<BulletScript>(CreateBullet,Onget,OnRelease,OnDestorBullet,maxSize:5);
    }

    public BulletScript CreateBullet()
    {
       BulletScript bullet= Instantiate(bulletPrefab,shootPosiotion.position,transform.rotation);
    //    bullet.transform.parent = transform;
        bullet.SetPool(n_bulletPool);
        return bullet;
    }
    public void Onget(BulletScript bullet)
    {
       
       
        bullet.gameObject.SetActive(true);
        bullet.transform.position = shootPosiotion.position;
        bullet.SetDirection(Player);
     //   bullet.transform.rotation = ;
        //bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward*10,ForceMode.Impulse);
    }
    public void OnRelease(BulletScript bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    public void OnDestorBullet(BulletScript bullet)
    {
        Destroy(bullet.gameObject);
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
