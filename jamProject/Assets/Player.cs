using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject edgeBox;
    public float movmentSpeed = 1.0F;
    public float torqueSpeed = 1.0F;
    public float maxVelocity = 1.75F;
    public float maxAngularVelocity = 400.0F;

    public static float VerticalSize
    {
        get
        {
            return Camera.main.orthographicSize;
        }
    }

    public static float HorizontalSize
    {
        get
        {
            return Camera.main.orthographicSize * (Screen.width / (float)Screen.height);
        }
    }

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        GameObject right = Instantiate(edgeBox, new Vector2(HorizontalSize + 0.5F, 0.0F), Quaternion.identity);
        GameObject left = Instantiate(edgeBox, new Vector2(-HorizontalSize - 0.5F, 0.0F), Quaternion.identity);
        left.transform.localScale = right.transform.localScale = new Vector2(1.0F, VerticalSize * 2.0F + 2.0F);

        GameObject up = Instantiate(edgeBox, new Vector2(0.0F, VerticalSize + 0.5F), Quaternion.identity);
        GameObject down = Instantiate(edgeBox, new Vector2(0.0F, -VerticalSize - 0.5F), Quaternion.identity);
        down.transform.localScale = up.transform.localScale = new Vector2(HorizontalSize * 2.0F + 2.0F, 1.0F);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddTorque(-1 * Time.fixedDeltaTime * torqueSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddTorque(1 * Time.fixedDeltaTime * torqueSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(Time.fixedDeltaTime * movmentSpeed * transform.up);
        }

        rigidBody.velocity = new Vector2(Mathf.Clamp(rigidBody.velocity.x, -maxVelocity, maxVelocity), Mathf.Clamp(rigidBody.velocity.y, -maxVelocity, maxVelocity));
        rigidBody.angularVelocity = Mathf.Clamp(rigidBody.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
    }
}

