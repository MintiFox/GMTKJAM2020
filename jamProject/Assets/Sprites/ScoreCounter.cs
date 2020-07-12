using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{

    public TextMeshProUGUI text;

    //how much score is added per second the game is running
    public float scorePerSecond;
    //score rounded down
    public int score;
    //score down to percent
    public float realScore;

    public static ScoreCounter instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else { Destroy(this); }
    }

    void FixedUpdate()
    {
        realScore += scorePerSecond * Time.fixedDeltaTime;

        score = (int)Mathf.Floor(realScore);
        text.text = score.ToString() + "m";

    }
}
