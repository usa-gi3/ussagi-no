
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    [SerializeField] private GameObject talkMark; // 会話可能マーク
    [SerializeField] private Camera mainCamera;   // メインカメラ

    void Start()
    {
        if (talkMark != null) talkMark.SetActive(false);//マークを非表示に
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (talkMark != null) talkMark.SetActive(true); // 範囲に入ったらマーク表示
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (talkMark != null) talkMark.SetActive(false); // 範囲から出たら非表示
        }
    }
    private void LateUpdate()
    {
        // マークをカメラの方向に向ける
        if (talkMark != null && talkMark.activeSelf)
        {
            talkMark.transform.LookAt(talkMark.transform.position + mainCamera.transform.forward);
        }
    }
}
