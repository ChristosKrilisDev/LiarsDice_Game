using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Just a simple camera controller cs.
/// Its rotate the camera arroud the target :p
/// </summary>
public class CameraController : MonoBehaviour
{

    public Transform target;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the cube by converting the angles into a quaternion.
        Quaternion newtarget = Quaternion.Euler(0 , transform.eulerAngles.y + 25 , 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation ,  newtarget , Time.deltaTime * 0.95f);

        transform.LookAt(target);
    }
}
