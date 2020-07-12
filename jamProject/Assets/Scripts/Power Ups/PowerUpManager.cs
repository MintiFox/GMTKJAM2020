using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Dictionary<Type, uint> activated = new Dictionary<Type, uint>();

    public static PowerUpManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else { Destroy(this); }
    }

    public bool IsActivated(System.Type type)
    {
        return PowerUpManager.instance.activated.TryGetValue(type, out uint v) && v > 0;
    }
}
