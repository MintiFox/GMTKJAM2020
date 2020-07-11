using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinBar : MonoBehaviour
{
   public Image barFill;
    public int currentCount;
    public int maxCount;


    public static CoinBar instance;

    private void Awake()
    {
        instance = this;
    }


    public void AddCoins(int coins)
    {
        currentCount += coins;

        if (AudioManager.instance != null)
        AudioManager.instance.coinSounds.PlayRandom();


        barFill.fillAmount = ((float)currentCount / (float)maxCount);
    }


}
