using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health = 100f;
    public GameObject explosion;
    PlayerBehaviour pb;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "bullet")
        {
            health -= 10;
            if (health == 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                
                Destroy(gameObject);
                
            }
        }

       
    }
}
