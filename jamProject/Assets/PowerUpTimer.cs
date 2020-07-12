using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpTimer : MonoBehaviour
{
    public Image img;
    //float timer;
    public Sprite[] images;

    public static PowerUpTimer instance;

    [ContextMenu("Debug Timer")]
    void debugTimer()
    {
        gameObject.SetActive(true);

        StartCoroutine(timer(5));
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void setTimer(int imageIndex, float time)
    {
        img.sprite = images[imageIndex];
        gameObject.SetActive(true);

        StartCoroutine(timer(time));
    }


    IEnumerator timer(float time)
    {

        float start = 0;
        while (start < time)
        {
            start += Time.fixedDeltaTime;
            img.fillAmount = 1 - start / time;
            yield return new WaitForFixedUpdate();
        }

        gameObject.SetActive(false);


    }
}
