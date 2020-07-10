using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector3 targetPos;
    public float distance;
    public float speed;
    public float maxDis;
    public float minDis;

    public float health = 3f;
    public Text healthUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        healthUI.text = health.ToString();

        if (health <= 0)
        {
            
        }


        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < maxDis)
        {
            targetPos = new Vector3(transform.position.x + distance, transform.position.y,transform.position.z);     

        }
        else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > minDis)
        {
            targetPos = new Vector3(transform.position.x - distance, transform.position.y,transform.position.z);

        }
    }
}

