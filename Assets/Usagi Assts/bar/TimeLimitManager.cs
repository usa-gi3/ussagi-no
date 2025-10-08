using UnityEngine;
using TMPro;

public class TimeLimitManager : MonoBehaviour
{
    public float timeLimit = 120f; // �������ԁi�b�j
    private float currentTime;

    public TextMeshProUGUI timerText; // UI�\���p

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
        Debug.Log("���Ԑ؂�I");
        // �����ɃQ�[���I�[�o�[�����������iUI�\���A�����~�Ȃǁj
    }
}