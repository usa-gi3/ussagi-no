using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    public OrderChecker orderChecker;

    void Start()
    {
        scoreText.text = "Score: 0";
    }

    public void UpdateScore(int newScore)
    {
        score = newScore;
        scoreText.text = "Score: " + score;
    }


}