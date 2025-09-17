using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setuyaku_Scene_ofice : MonoBehaviour
{
    public GameObject One_Camera; // カメラ1
    public GameObject Two_Camera; // カメラ2
    public GameObject player;     // プレイヤーオブジェクト

    // Bar1とBar2の移動先座標
    Vector3 ofice1Position = new Vector3(10.88f,2.78f,11.6f);
    Vector3 ofice2Position = new Vector3(3.05f, -2.62f, 4.8f);

    private Collider triggeredObject = null; // 現在接触しているトリガー

    void Start()
    {
        One_Camera.SetActive(true);
        Two_Camera.SetActive(false);
    }

    // トリガーに入ったときに記録
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ofice1") || other.CompareTag("ofice2"))
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
            if (triggeredObject.CompareTag("ofice1"))
            {
                One_Camera.SetActive(true);
                Two_Camera.SetActive(false);
                player.transform.position = ofice1Position;
            }
            else if (triggeredObject.CompareTag("ofice2"))
            {
                One_Camera.SetActive(false);
                Two_Camera.SetActive(true);
                player.transform.position = ofice2Position;
            }

            triggeredObject = null; // 処理後にリセット
        }
    }
}