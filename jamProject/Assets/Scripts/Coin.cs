using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public float speed;
    public float magnetSpeed;

    //public int coins;
    //public Text coinsUI;
    private Transform player;
    private bool inMagnet = false;
    public GameObject coinEffect;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (inMagnet && PowerUpManager.instance.IsActivated(typeof(CoinMagnet)))
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * magnetSpeed);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        //coinsUI.text = coins.ToString();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinBar.instance.AddCoins(1);

            if (coinEffect != null)
            {
                GameObject go = Instantiate(coinEffect);
                go.transform.parent = other.transform;
                go.transform.position = other.transform.position;
            }

            Destroy(gameObject, 0.1f);


        } 
        else if (other.CompareTag("Coin Magnet"))
        {
            inMagnet = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Coin Magnet"))
        {
            inMagnet = false;
        }
    }
}
