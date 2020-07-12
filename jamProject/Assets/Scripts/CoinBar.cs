﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinBar : MonoBehaviour
{
   public Image barFill;
    public int currentCount;
    public int maxCount;


    public static CoinBar instance;
    public int[] soundLevelAtCount;


    private void Awake()
    {
        instance = this;
    }


    public void AddCoins(int coins)
    {
        currentCount += coins;

        if (AudioManager.instance != null && coins > 0)
        {
            AudioManager.instance.coinSounds.playSequential(soundLevelAtCount[currentCount]);
        }

        barFill.fillAmount = ((float)currentCount / (float)maxCount);
    }


}
