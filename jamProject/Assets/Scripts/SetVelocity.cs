using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SetVelocity : MonoBehaviour
{
    public Vector2 initialVelocity;
    Rigidbody2D rb;

    public enum ReletiveSpace
    {
        World, Local
    }
    public ReletiveSpace relativeSpace;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (relativeSpace.Equals(ReletiveSpace.World))
        {
            rb.velocity = initialVelocity;
        }
        else if (relativeSpace.Equals(ReletiveSpace.Local))
        {
            rb.velocity = transform.InverseTransformDirection(initialVelocity);
        
        }



    }

   
}
