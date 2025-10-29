using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Point_Sum : MonoBehaviour
{
    public int score = 0;

    public GameObject Carrot1;
    public GameObject Carrot2;
    public GameObject Carrot3;
    public GameObject Carrot4;
    public GameObject Carrot5;
    public GameObject Carrot6;
    public GameObject ClearSeen;

    public static int ClearFlag_town = 0;

    void Start()
    {
        Carrot1.SetActive(false);
        Carrot2.SetActive(false);
        Carrot3.SetActive(false);
        Carrot4.SetActive(false);
        Carrot5.SetActive(false);
        Carrot6.SetActive(false);
        ClearSeen.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("point"))
        {
            score += 10;
            Debug.Log("ポイントゲット！現在のスコア: " + score);

            // オブジェクトを消したい場合はこれも追加
            Destroy(other.gameObject);
        }

        if (score > 100)
        {
            Carrot1.SetActive(true);
            ClearFlag_town = 1;
            ClearSeen.SetActive(true);

        }  
        if (score > 200)
        {
            Carrot2.SetActive(true);

        } 
        if (score > 300)
        { 
         
            Carrot3.SetActive(true);
        }
        
        if (score > 400)
        {
            Carrot4.SetActive(true);
        }
        
        if (score > 500)
        {
            Carrot5.SetActive(true);
        }
        
        if (score > 600)
        {
            Carrot6.SetActive(true);
        }

        if (score > 700)
        {
            ClearFlag_town = 1;
            ClearSeen.SetActive(true);

            
        }
    }

    void Update()
    {
        if(ClearFlag_town == 1){
            if (Input.GetMouseButtonDown(0)) // 左クリック
            {
                SceneManager.LoadScene("Shop_Scene");
            }
        }
    }



}
