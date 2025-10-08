using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSpot : MonoBehaviour
{
    public int avatarID; // ���̃X�|�b�g�őI�΂��A�o�^�[�ԍ�
    private AvatarChanger changer;

    void Start()
    {
        changer = FindObjectOfType<AvatarChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[���G���A�ɓ�������A���̃G���A��p�̕ϐg���ݒ�
        if (other.CompareTag("Player"))
        {
            changer.SetAvatar(avatarID);
            Debug.Log("�G���A " + avatarID);
        }
    }
}

