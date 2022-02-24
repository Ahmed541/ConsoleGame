using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
       
        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
            //transform.rotation = target.rotation;
            //target.rotation = Quaternion.Euler(0, 0, 0);

        }

        //// compute rotation
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    if (lookAt)
        //    {
        //        transform.LookAt(target);

        //    }
        //    else
        //    {

        //        transform.rotation = target.rotation;

        //    }
        //}
    }
}
