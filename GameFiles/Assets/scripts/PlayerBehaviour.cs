using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private Rigidbody rb;
    public float jumpForce;
    public float rollSpeed;
    Animator anim;
    float dirX;
    float dirZ;

    public Camera cam;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 90.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();


        cam = GetComponent<Camera>();



        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

    }

    

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        //ProcessInputs();
        //dirX = Input.GetAxis("Horizontal");
        dirZ = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, jumpForce, dirZ);
        }

        if (Input.GetKeyDown("w"))
        {
            rb.AddForce(new Vector3(dirX, 0f, dirZ) * rollSpeed);

        }

        if (Input.GetKeyDown("a"))
        {
            
         
            
            

        }
        if (Input.GetKeyDown("d"))
        {
            transform.Rotate(0, 90, 0);
        }


        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    rb.AddForceAtPosition(-transform.position, transform.position);
        //}

        //Animation for jump
        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Active");
        }
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

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        dirX = Input.GetAxis("Horizontal");
        dirZ = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rb.AddForce(new Vector3(dirX, 0f, dirZ) * rollSpeed);
        rb.MoveRotation(transform.rotation);
    }
}