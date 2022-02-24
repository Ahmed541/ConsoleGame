using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.A))
        {
            
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0.0f, 90.0f, 0.0f));
        }
    }
}