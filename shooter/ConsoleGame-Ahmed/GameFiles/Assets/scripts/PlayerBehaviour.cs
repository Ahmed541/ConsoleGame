using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float rollSpeed;
    private Rigidbody rb;

    private Vector3 movement;
   
 
    public Camera cam;

    public gun gun;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      
        cam = FindObjectOfType<Camera>();
 
    }

    

    void Update()
    {

    

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

      
        //create a ray from our camera to our mouse position
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        //ray hits the ground where the mouse looks at.
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        //raylength = size of ray from camera to ground
        float rayLength;

        //returns true if ray hits the ground
        if(ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        //fires a bullet when the right mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            gun.isFiring = true;
        }

     
        if (Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }



    }

    void FixedUpdate()
    {
        //movement of player
        rb.position = (rb.position + movement * rollSpeed * Time.deltaTime);
     

        
    }

    //Die and Win
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Die")
        {
            GameManager.gameOver = true;
        }
        
        else if (collision.transform.tag == "Win")
        {
            GameManager.WinLevel = true;
        }
    }

    

    
}