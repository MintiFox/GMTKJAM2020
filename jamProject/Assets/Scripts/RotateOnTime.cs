using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnTime : MonoBehaviour
{

    public Vector3 speed;



   

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(speed * Time.fixedDeltaTime);
    }
}
