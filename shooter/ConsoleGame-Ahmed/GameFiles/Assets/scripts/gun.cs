using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public bool isFiring;

    public bullet bullet;
    public float bulletSpeed;

    public float timeBetweenBullets;
    private float bulletCounter;

    public Transform startPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (isFiring == true)
        {
            //makes sure our bullet counter is counting down 
            bulletCounter -= Time.deltaTime;
            //if our bullet counter is below zero it will fire a bullet
            if (bulletCounter <= 0)
            {
                //reset the counter
                bulletCounter = timeBetweenBullets;
                //creates a bullet in the scene at our starting position in the scene as a bullet gameobject
                bullet newbullet = Instantiate(bullet, startPoint.position, startPoint.rotation) as bullet;
                //set bullet speed
                newbullet.speed = bulletSpeed;
            }
            
        }
    }
}
