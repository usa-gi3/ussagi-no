using UnityEngine;
using TMPro;

public class TimeLimitManager : MonoBehaviour
{
    public float timeLimit = 120f; // 制限時間（秒）
    private float currentTime;

    public TextMeshProUGUI timerText; // UI表示用

    void Start()
    {
        currentTime = timeLimit;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();
        }
        else
        {
            timerText.text = "Time: 0";
            GameOver(); // 時間切れ処理
        }
    }

    void GameOver()
    {
        Debug.Log("時間切れ！");
        // ここにゲームオーバー処理を書く（UI表示、操作停止など）
    }
}