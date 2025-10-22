using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeLimitManager : MonoBehaviour
{
    public float timeLimit = 120f; // 制限時間（秒）
    private float currentTime;
    public GameObject ClearSeen;

    public TextMeshProUGUI timerText; // UI表示用
    public int ClearFlag = 0;

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
        ClearSeen.SetActive(true);

        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            SceneManager.LoadScene("Bar_Scene");
        }

        ClearFlag++;
    }
}