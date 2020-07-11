using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 3;

    public Image[] hearts;

    public Sprite fullSprite;
    public Sprite emptySprite;

    public void Damage(int dmg)
    {
        health -= dmg;
        updateUI();

        if (AudioManager.instance != null)
        AudioManager.instance.playerHurtSounds.PlayRandom();


        if (health <= 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }


    void updateUI()
    {
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullSprite;


        }
        for (int i = health; i < hearts.Length; i++)
        {
            hearts[i].sprite = emptySprite;
        }
    
    }





}
