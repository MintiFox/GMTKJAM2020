using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Dictionary<Type, uint> activated = new Dictionary<Type, uint>();
    public PowerUpItem[] items;

    public static PowerUpManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else { Destroy(this); }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PowerUpItem item = new PowerUpItem();
            foreach (PowerUpItem current in items)
            {
                if (current.cost >= item.cost && current.cost <= CoinBar.instance.currentCount
                    && (item = current).cost == CoinBar.instance.currentCount)
                {
                    break;
                }
            }
            if (item.powerUp != null)
            {
                CoinBar.instance.AddCoins(-CoinBar.instance.currentCount);
                item.powerUp.Activate();
                if (item.powerUp.duration > 0.0F)
                {
                    PowerUpTimer.instance.setTimer(item.powerUp.imageIndex, item.powerUp.duration);
                }
            }
        }
    }

    public bool IsActivated(Type type)
    {
        return PowerUpManager.instance.activated.TryGetValue(type, out uint v) && v > 0;
    }

    [Serializable]
    public struct PowerUpItem
    {
        public PowerUp powerUp;
        public int cost;
    }
}
