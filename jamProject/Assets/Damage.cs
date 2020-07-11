﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GetComponent<invincible>().InvIsActive != true)
        {
            GetComponent<Health>().health = GetComponent<Health>().health - damage;
        }
        else
        {
            Destroy(gameObject, 0.1f);
        }
    }
 }