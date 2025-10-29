using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Start : MonoBehaviour
{
    public GameObject Player;

    public InkController inkController;

    Vector3 Player_Position = new Vector3(3.751f, -3.806f, 3.059f);


    [Header("PlayerPrefsの値（読み取り専用）")]
    [SerializeField] private int clear;

    int i = 1;

    // Start is called before the first frame update
    void Start()
    {


        clear = Point_Sum.ClearFlag_town;


        if (clear == 1)
        {
            Debug.Log("ステージ1はクリア済み！");
            Player.transform.position = Player_Position;
            inkController.StartDialogue();

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
