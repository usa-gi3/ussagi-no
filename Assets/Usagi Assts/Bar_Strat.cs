using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_Strat : MonoBehaviour
{
    public GameObject Chair;
    public GameObject Player;

    public InkController inkController;

    Vector3 Player_Position = new Vector3(0.124f, -5.756f, 6.339f);


    [Header("PlayerPrefs�̒l�i�ǂݎ���p�j")]
    [SerializeField] private int clear;

    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        

        clear = TimeLimitManager.ClearFlag;


        if (clear == 1)
        {
            Debug.Log("�X�e�[�W1�̓N���A�ς݁I");
            Chair.SetActive(false);
            Player.transform.position = Player_Position;

            inkController.StartDialogue();

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
