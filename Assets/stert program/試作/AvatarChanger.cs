using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChanger : MonoBehaviour
{
    [Header("Animator & Avatars")]
    public Animator animator;              // ��̃I�u�W�F�N�g�ɂ��Ă�Animator
    public GameObject defaultModel;        // �f�t�H���g�̌����ځiAnimator�͍폜���Ă����j
    public Avatar defaultAvatar;           // �f�t�H���g�p��Avatar
    public GameObject[] avatarPrefabs;     // �ϐg��̌����ځi�v���n�u�j
    public Avatar[] avatars;               // �e�ϐg���Avatar�iHumanoid�j

    private GameObject currentAvatarObj;   // ���o���Ă�A�o�^�[�i���́j
    private int currentAvatarID = -1;      // ���I�΂�Ă�A�o�^�[�ԍ�
    private bool isTransformed = false;    // ���ϐg���Ă邩�ǂ���

    void Update()
    {
        // C�L�[�ŕϐg�E����
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleAvatar();
        }
    }

    // �ϐg or ���ɖ߂�
    void ToggleAvatar()
    {
        if (isTransformed)
        {
            // ���ɖ߂�����
            if (currentAvatarObj != null)
            {
                Destroy(currentAvatarObj); // �ϐg���̃��f���폜
                currentAvatarObj = null;
            }

            defaultModel.SetActive(true);   // �f�t�H���g�̌����ڂ�߂�
            animator.avatar = defaultAvatar;
            animator.Rebind();
            animator.Update(0);

            isTransformed = false;
        }
        else
        {
            // �ϐg���鏈��
            if (currentAvatarID < 0 || currentAvatarID >= avatarPrefabs.Length)
            {
                Debug.LogWarning("�ϐg�悪�ݒ肳��ĂȂ���I");
                return;
            }

            // �Â����f��������Ώ���
            if (currentAvatarObj != null)
                Destroy(currentAvatarObj);

            // �V�����A�o�^�[���o��

            currentAvatarObj = Instantiate(avatarPrefabs[currentAvatarID], transform);
            currentAvatarObj.transform.localPosition = Vector3.zero;
            currentAvatarObj.transform.localRotation = Quaternion.identity;
            currentAvatarObj.transform.localScale = Vector3.one;
            currentAvatarObj.tag = "Player"; // �v���C���[�^�O������

            defaultModel.SetActive(false);   // �f�t�H���g�̌����ڂ�����

            animator.avatar = avatars[currentAvatarID];
            animator.Rebind();
            animator.Update(0);

            isTransformed = true;
        }
    }

    // ���̃X�N���v�g����ϐg����w��ł���悤�ɂ���
    public void SetAvatar(int id)
    {
        if (id >= 0 && id < avatarPrefabs.Length)
        {
            currentAvatarID = id;
            Debug.Log("�ϐg��� " + avatarPrefabs[id].name + " �ɐݒ肵����");
        }
        else
        {
            Debug.LogWarning("����ID�̃A�o�^�[�͑��݂��Ȃ���I");
        }
    }
}

