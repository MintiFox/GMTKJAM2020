using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//worked on by MintFox
public class HighScoreBoard : MonoBehaviour
{
    public int[] scores;
    public TextMeshProUGUI[] boardTexts;

    [Space(10)]
    [Header("Right click the debug score and press 'Add Score'")]
    [ContextMenuItem("Reset Score", "ResetScore")]
    [ContextMenuItem("Add Score", "DebugScoreAdd")]
    public int debugScore = 0;

    private void Start()
    {
        if (scores == null)
            scores = new int[5];
        if (boardTexts == null)
            boardTexts = new TextMeshProUGUI[5];

        LoadScores();
    }


    void LoadScores()
    {

        scores[0] = PlayerPrefs.GetInt("Score1", 0);
        scores[1] = PlayerPrefs.GetInt("Score2", 0);
        scores[2] = PlayerPrefs.GetInt("Score3", 0);
        scores[3] = PlayerPrefs.GetInt("Score4", 0);
        scores[4] = PlayerPrefs.GetInt("Score5", 0);

        SetBoardText();

    }
    void SetBoardText()
    {
        boardTexts[0].text = scores[0].ToString();
        boardTexts[1].text = scores[1].ToString();
        boardTexts[2].text = scores[2].ToString();
        boardTexts[3].text = scores[3].ToString();
        boardTexts[4].text = scores[4].ToString();

    }


    public void DebugScoreAdd()
    {
        AddScore(debugScore);
    
    }


    public void ResetScore()
    {
        PlayerPrefs.SetInt("Score1", 0);
        PlayerPrefs.SetInt("Score2", 0);
        PlayerPrefs.SetInt("Score3", 0);
        PlayerPrefs.SetInt("Score4", 0);
        PlayerPrefs.SetInt("Score5", 0);

        LoadScores();

    }

    //very brute force, but for the sake of time, I'm not worrying about elegance.
    public void AddScore(int score)
    {

        if (score > scores[0])
        {
            scores = new int[] { score, scores[0], scores[1], scores[2], scores[3] };
        }
        else if (score > scores[1])
        {
            scores = new int[] { scores[0], score, scores[1], scores[2], scores[3] };

        }
        else if (score > scores[2])
        {
            scores = new int[] { scores[0], scores[1], score, scores[2], scores[3] };

        }
        else if (score > scores[3])
        {
            scores = new int[] {  scores[0], scores[1], scores[2], score, scores[3] };

        }
        else if (score > scores[4])
        {
            scores = new int[] {  scores[0], scores[1], scores[2], scores[3], score };

        }


        SaveScores();
    }

    void SaveScores()
    {
        PlayerPrefs.SetInt("Score1", scores[0]);
        PlayerPrefs.SetInt("Score2", scores[1]);
        PlayerPrefs.SetInt("Score3", scores[2]);
        PlayerPrefs.SetInt("Score4", scores[3]);
        PlayerPrefs.SetInt("Score5", scores[4]);

        LoadScores();
    }

    


}
