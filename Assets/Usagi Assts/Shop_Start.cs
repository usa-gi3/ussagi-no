using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Start : MonoBehaviour
{
    public GameObject Player;

    public InkController_Shop inkController;

    Vector3 Player_Position = new Vector3(18.5f, -304f, 341f);

    public GameObject Carrot;

    [Header("PlayerPrefs�̒l�i�ǂݎ���p�j")]
    [SerializeField] private int clear;

    int i = 1;

    // Start is called before the first frame update
    void Start()
    {

       
        clear = Point_Sum.ClearFlag_town;



        if (clear == 1)
        {
            Debug.Log("�X�e�[�W1�̓N���A�ς݁I");
            Player.transform.position = Player_Position;
            inkController.StartDialogue();
            Carrot.SetActive(this);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
