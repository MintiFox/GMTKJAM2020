using UnityEngine;

public class Player : MonoBehaviour
{
    public float movmentSpeed = 1.0F;
    public float torqueSpeed = 1.0F;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
    }
}

