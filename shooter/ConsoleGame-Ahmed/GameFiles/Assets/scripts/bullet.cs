using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
      //makes bullet go forward
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
      Destroy(gameObject, 1f);
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "enemy")
        {
           Destroy(gameObject);
            
        }


    }

}
