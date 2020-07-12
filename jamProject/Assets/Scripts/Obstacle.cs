using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 3f;
    public float maxHeight = 10.0F;

    void Update()
    {
        if (transform.position.y > maxHeight)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }   
    }
}
