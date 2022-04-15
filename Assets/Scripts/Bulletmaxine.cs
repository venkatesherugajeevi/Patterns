using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bulletmaxine : MonoBehaviour
{
    public BulletScript bulletPrefab;

    public Transform ShootPosition;

    public int NoofBullets = 10;
    public delegate void Healthattack();
    [SerializeField]
    public event Healthattack attackEvent;

    public UnityEvent shootEvent;

    List<BulletScript> Bullets;
    private void Awake()
    {
        Bullets = new List<BulletScript>();
        for(int i = 0; i < NoofBullets; i++)
        {
          BulletScript bullet=  Instantiate(bulletPrefab, ShootPosition.position, Quaternion.identity);
            bullet.gameObject.SetActive(false);
            bullet.transform.parent = transform;
            Bullets.Add(bullet);
        }
    }

    void Start()
    {
        //  attackEvent += AudioPlay;
        // attackEvent+= EffectsPla;
        //shootEvent.AddListener(AudioPlay);
       // shootEvent.AddListener(EffectsPla);



    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shootbullets();
            //   attackEvent.Invoke();
            shootEvent.Invoke();
        }
    }
    void Shootbullets()
    {
        foreach(BulletScript bullet in Bullets)
        {
            if(!bullet.gameObject.activeInHierarchy)
            {
                bullet.transform.position = ShootPosition.position;
                bullet.gameObject.SetActive(true);
                break;
            }
        }
    }
    public void AudioPlay()
    {
        Debug.Log("audio source playing");
    }
    public void EffectsPla()
    {

        Debug.Log("Effect is playing");
    }

}

