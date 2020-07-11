using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    public float max = 2.0F;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position - Camera.main.transform.position;
        if (Mathf.Abs(currentPosition.x) > Player.HorizontalSize + max 
            || Mathf.Abs(currentPosition.y) > Player.VerticalSize + max)
        {
            Destroy(gameObject);
        }
    }
}
