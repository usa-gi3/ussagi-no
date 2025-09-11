using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setuyaku_Scene : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject One_Camera; // カメラ1
    public GameObject Two_Camera; // カメラ2

    // 移動先の座標（Bar1とBar2）
    Vector3 Bar1Position = new Vector3(1.466238f, -5.756f, 3.129455f);
    Vector3 Bar2Position = new Vector3(-7f, 5f, 3f);

    private string currentTrigger = ""; // 現在接触しているオブジェクトのタグ

    // ゲーム開始時にカメラ1を有効化
=======
    public GameObject One_Camera;
    public GameObject Two_Camera;
    public GameObject player; // プレイヤーを指定

    Vector3 Bar1Position = new Vector3(-5.845f, -5.756f, 3.512f);
    Vector3 Bar2Position = new Vector3(0.252f, 0.152f, 0.672f);

    private Collider triggeredObject;

>>>>>>> mochi
    void Start()
    {
        One_Camera.SetActive(true);
        Two_Camera.SetActive(false);
    }

    // トリガーに入ったときにタグを記録
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bar1") || other.CompareTag("Bar2"))
        {
<<<<<<< HEAD
            currentTrigger = other.tag;
        }
    }

    // トリガーから出たときにタグをリセット
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bar1") || other.CompareTag("Bar2"))
        {
            currentTrigger = "";
        }
    }

    // スペースキーが押されたら、タグに応じて処理を実行
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentTrigger == "Bar1")
            {
                One_Camera.SetActive(true);
                Two_Camera.SetActive(false);
                transform.position = Bar1Position;
            }
            else if (currentTrigger == "Bar2")
            {
                One_Camera.SetActive(false);
                Two_Camera.SetActive(true);
                transform.position = Bar2Position;
            }
        }
    }
=======
            triggeredObject = other;
        }
    }

    void Update()
    {
        if (triggeredObject != null && Input.GetKeyDown(KeyCode.Space))
        {
            if (triggeredObject.CompareTag("Bar1"))
            {
                One_Camera.SetActive(true);
                Two_Camera.SetActive(false);
                player.transform.position = Bar1Position;
            }
            else if (triggeredObject.CompareTag("Bar2"))
            {
                One_Camera.SetActive(false);
                Two_Camera.SetActive(true);
                player.transform.position = Bar2Position;
            }

            triggeredObject = null;
        }
    }
>>>>>>> mochi
}