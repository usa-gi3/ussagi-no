using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeLimitManager : MonoBehaviour
{
    public float timeLimit = 120f; // �������ԁi�b�j
    private float currentTime;
    public GameObject ClearSeen;

    public TextMeshProUGUI timerText; // UI�\���p

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
            GameOver(); // ���Ԑ؂ꏈ��
        }
    }

    void GameOver()
    {
        ClearSeen.SetActive(true);

        ClearScore = scoreManager.score;



        ClearFlag = 1;

        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            SceneManager.LoadScene("Bar_Scene");
        }

        
    }
}