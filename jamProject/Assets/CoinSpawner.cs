using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;

    public float coinRate = 5;
    public float nextCoin = 1;

// Update is called once per frame
    void Update()
    {
        nextCoin -= Time.deltaTime;
        if (nextCoin <= 0) {
            nextCoin = coinRate;

            Vector3 CoinPos = new Vector3(Random.Range(-8f, 8f), Random.Range(-6f, -8f), 0f);
            Instantiate(coin, CoinPos, Quaternion.identity);
        }

    }
}
