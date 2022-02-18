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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    

    void Update()
    {
        ProcessInputs();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(dirX, jumpForce, dirZ);
        }


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
    }
}