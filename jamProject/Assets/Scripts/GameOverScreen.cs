using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{

    public ScoreCounter sc;
    public TextMeshProUGUI scoreText;
    public GameObject highscoretext;

    HighScoreBoard hsb;

    public void GameOver()
    {
        StopGame();

        gameObject.SetActive(true);
        sc.scorePerSecond = 0;
        scoreText.text = sc.score.ToString() + "m";

        hsb = new HighScoreBoard();

        if (hsb.AddScore(sc.score))
        { highscoretext.SetActive(true); }

    }

    private void StopGame()
    {
        // PLAYER
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        // SPAWNER
        Destroy(FindObjectOfType<CoinSpawner>());
        Destroy(PowerUpManager.instance);
        PowerUpManager.instance = null;
    }
}
