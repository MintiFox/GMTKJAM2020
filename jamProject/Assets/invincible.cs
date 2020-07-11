using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincible : MonoBehaviour
{
    public float lastTimer = 10;

    public bool InvIsActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J) && CoinBar.instance.currentCount >= 5 && lastTimer > 0)
        {
            lastTimer -= Time.deltaTime;
            InvIsActive = true;
        }
        else
        {
            InvIsActive = false;
        }
    }

}
