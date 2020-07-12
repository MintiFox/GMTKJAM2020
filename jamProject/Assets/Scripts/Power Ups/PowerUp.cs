using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Power Up Settings")]
    public int imageIndex;
    public float duaration;
    public bool autoRemove = true;

    public void Activate()
    {
        StartCoroutine(PowerUpRoutine());
    }

    protected IEnumerator PowerUpRoutine()
    {
        if (!PowerUpManager.instance.activated.ContainsKey(GetType()))
        {
            PowerUpManager.instance.activated.Add(GetType(), 0);
        }

        if (++PowerUpManager.instance.activated[GetType()] == 1)
        {
            ApplyPowerUp();
        }
        yield return new WaitForSeconds(duaration);
        if (autoRemove && (PowerUpManager.instance.activated[GetType()] = Math.Max(1, PowerUpManager.instance.activated[GetType()]) - 1) == 0)
        {
            RemovePowerUp();
        }
    }

    public virtual void ApplyPowerUp()
    {
    }

    public virtual void RemovePowerUp()
    {
    }
}
