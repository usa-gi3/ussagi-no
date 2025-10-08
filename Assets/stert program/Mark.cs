using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    [SerializeField] private GameObject EnterMark; // 会話可能マーク
    [SerializeField] private Camera mainCamera;   // メインカメラ

    void Start()
    {
        if (EnterMark != null) EnterMark.SetActive(false);//マークを非表示に
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (EnterMark != null) EnterMark.SetActive(true); // 範囲に入ったらマーク表示
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (EnterMark != null) EnterMark.SetActive(false); // 範囲から出たら非表示
        }
    }
    private void LateUpdate()
    {
        // マークをカメラの方向に向ける
        if (EnterMark != null && EnterMark.activeSelf)
        {
            EnterMark.transform.LookAt(EnterMark.transform.position + mainCamera.transform.forward);
        }
    }
}
