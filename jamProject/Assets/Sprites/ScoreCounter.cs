using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{

    public TextMeshProUGUI text;

    public float scorePerSecond;
    public int score;
    public float realScore;
    
    void FixedUpdate()
    {
        realScore += scorePerSecond * Time.fixedDeltaTime;

        score = (int)Mathf.Floor(realScore);
        text.text = score.ToString() + "m";

    }
}
