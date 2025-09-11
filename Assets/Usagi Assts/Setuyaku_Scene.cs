using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setuyaku_Scene : MonoBehaviour
{
    public GameObject One_Camera; // カメラ1
    public GameObject Two_Camera; // カメラ2
    public GameObject player;     // プレイヤーオブジェクト

    // Bar1とBar2の移動先座標
    Vector3 Bar1Position = new Vector3(1.466238f, -5.756f, 3.129455f);
    Vector3 Bar2Position = new Vector3(-7f, 5f, 3f);

    private Collider triggeredObject = null; // 現在接触しているトリガー

    void Start()
    {
        One_Camera.SetActive(true);
        Two_Camera.SetActive(false);
    }

    // トリガーに入ったときに記録
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bar1") || other.CompareTag("Bar2"))
        {
            triggeredObject = other;
        }
    }

    // トリガーから出たときにリセット
    void OnTriggerExit(Collider other)
    {
        if (other == triggeredObject)
        {
            triggeredObject = null;
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

            triggeredObject = null; // 処理後にリセット
        }
    }
}