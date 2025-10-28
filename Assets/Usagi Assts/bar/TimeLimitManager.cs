using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeLimitManager : MonoBehaviour
{
    public float timeLimit = 120f; // 制限時間（秒）
    private float currentTime;
    public GameObject ClearSeen;

    public TextMeshProUGUI timerText; // UI表示用

    public ScoreManager scoreManager;


    public static int ClearFlag = 0;

    public static int ClearScore = 0;

    public static TimeLimitManager Instance;

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
        ClearSeen.SetActive(true);

        ClearScore = scoreManager.score;



        ClearFlag = 1;

        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            SceneManager.LoadScene("Bar_Scene");
        }

        
    }
}