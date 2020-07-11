using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public float speed;

    //public int coins;
    //public Text coinsUI;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        //coinsUI.text = coins.ToString();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinBar.instance.AddCoins(1);
            Destroy(gameObject, 0.1f);
        }
    }
}
