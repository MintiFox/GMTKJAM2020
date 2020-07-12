using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float movmentSpeed = 1.0F;
    public float torqueSpeed = 1.0F;
    public float maxVelocity = 1.75F;
    public float maxAngularVelocity = 400.0F;

    [Header("Spawn")]
    public uint maxHazards;
    public AnimationCurve spawnTime = new AnimationCurve();

    [Header("Walls")]
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    private Spawner[] spawner;

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
        InstantiateWalls();
    }

    void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(spawnTime.Evaluate(Time.time));
            if (maxHazards == 0 || GameObject.FindGameObjectsWithTag("Hazard").Length < maxHazards)
            {
                StartCoroutine(spawner[UnityEngine.Random.Range(0, spawner.Length - 1)].Spawn());
            }
        }
    }

    private void InstantiateWalls()
    {
        Vector2 hPos = new Vector2(HorizontalSize + 0.5F, 0.0F);
        Vector2 vPos = new Vector2(0.0F, VerticalSize + 0.5F);
        Vector2 vSize = new Vector2(VerticalSize * 2.0F + 2.0F, 1.0F);
        Vector2 hSize = new Vector2(HorizontalSize * 2.0F + 2.0F, 1.0F);

        // IN
        GameObject up = Instantiate(this.up, Vector3.zero, Quaternion.identity);
        GameObject down = Instantiate(this.down, Vector3.zero, Quaternion.identity);
        GameObject left = Instantiate(this.left, Vector3.zero, Quaternion.identity);
        GameObject right = Instantiate(this.right, Vector3.zero, Quaternion.identity);

        // SCALE
        right.transform.localScale = left.transform.localScale = vSize;
        down.transform.localScale = up.transform.localScale = hSize;

        // PARENT
        right.transform.parent = left.transform.parent = down.transform.parent = up.transform.parent = Camera.main.transform;

        // MOVE
        right.transform.localPosition = hPos;
        left.transform.localPosition = -hPos;
        up.transform.localPosition = vPos;
        down.transform.localPosition = -vPos;
        
        // ROTATE
        right.transform.localRotation = Quaternion.Euler(0.0F, 0.0F, 90F);
        left.transform.localRotation = Quaternion.Euler(0.0F, 0.0F, -90F);
        up.transform.localRotation = Quaternion.Euler(0.0F, 0.0F, 180F);
        down.transform.localRotation = Quaternion.identity;

        spawner = new Spawner[]
        {
            down.GetComponent<Spawner>(),
            down.GetComponent<Spawner>(),
            left.GetComponent<Spawner>(),
            right.GetComponent<Spawner>()
        };
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

