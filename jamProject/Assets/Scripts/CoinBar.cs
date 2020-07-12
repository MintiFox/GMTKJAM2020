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
    public int[] soundLevelAtCount;

    public Image img;
    public Sprite[] powerUpSprites;
    public int[] powerUpAtCost;

    private void Awake()
    {
        instance = this;
    }


    public void AddCoins(int coins)
    {
        currentCount += coins;

        if (currentCount > maxCount) currentCount = maxCount;

        if (AudioManager.instance != null && coins > 0)
        {
            AudioManager.instance.coinSounds.playSequential(soundLevelAtCount[currentCount - 1]);
        }

        UpdateUI();

        barFill.fillAmount = ((float)currentCount / (float)maxCount);
    }


    void UpdateUI()
    {

        if (currentCount <= 1)
        {
            img.gameObject.SetActive(false);
            return;
        }

        img.gameObject.SetActive(true);

        img.sprite = powerUpSprites[powerUpAtCost[currentCount]];
        img.gameObject.SetActive(true);

    }

}
