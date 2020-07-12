using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Component[] toDestroy;
    public float duaration;
    public PowerUpManager manager;
    public bool autoRemove = true;

    public float speed = 2.0F;
    private bool collected;

    void Update()
    {
        if (!collected)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collected = true;
            foreach (Component component in toDestroy)
            {
                Destroy(component);
            }
            StartCoroutine(PowerUpRoutine());
        }
    }

    protected IEnumerator PowerUpRoutine()
    {
        if (!manager.activated.ContainsKey(GetType()))
        {
            manager.activated.Add(GetType(), 0);
        }

        if (++manager.activated[GetType()] == 1)
        {
            ApplyPowerUp();
        }
        yield return new WaitForSeconds(duaration);
        if (autoRemove && (manager.activated[GetType()] = Math.Max(1, manager.activated[GetType()]) - 1) == 0)
        {
            RemovePowerUp();
        }
        Destroy(gameObject);
    }

    public virtual void ApplyPowerUp()
    {
    }

    public virtual void RemovePowerUp()
    {
    }
}
