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



    public float coolDown = 5;
    private float cooldownTimer;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      
        cam = FindObjectOfType<Camera>();


        currentAmmo = maxAmmo;
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

        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }


        //fires a bullet when the right mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
                currentAmmo--;
            }

       
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        //movement of player
        rb.position = (rb.position + movement * rollSpeed * Time.deltaTime);
     

        
    }


    IEnumerator Reload()
    {
        isReloading = true;
        

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }



}