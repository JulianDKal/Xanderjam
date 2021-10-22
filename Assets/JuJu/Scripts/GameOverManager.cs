using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI newRecordText;

    private int score;

    private void Start()
    {
        score = CollectableManager.playerScore;
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
            newRecordText.text = "New Record!";
        }
        else newRecordText.text = "your record: " + PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = score.ToString();
    }
}
