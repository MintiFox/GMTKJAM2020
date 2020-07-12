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
    public GameOverScreen gos;

    public GameObject hitEffect;

    public void Damage(int dmg)
    {
        if (!PowerUpManager.instance.IsActivated(typeof(Invincibility)))
        {
            health -= dmg;
            updateUI();

            if (AudioManager.instance != null)
            AudioManager.instance.playerHurtSounds.PlayRandom();

            if (hitEffect != null)
            {
             GameObject go =  Instantiate(hitEffect);
                go.transform.position = transform.position;
            }


            if (health <= 0)
            {
                gos.GameOver();
            }
        }
    }


    void updateUI()
    {

        if (health < 0)
            health = 0;

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
