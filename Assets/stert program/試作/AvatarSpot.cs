using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSpot : MonoBehaviour
{
    public int avatarID; // このスポットで選ばれるアバター番号
    private AvatarChanger changer;

    void Start()
    {
        changer = FindObjectOfType<AvatarChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーがエリアに入ったら、そのエリア専用の変身先を設定
        if (other.CompareTag("Player"))
        {
            changer.SetAvatar(avatarID);
            Debug.Log("エリア " + avatarID);
        }
    }
}

