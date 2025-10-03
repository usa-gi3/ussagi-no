using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChanger : MonoBehaviour
{
    [Header("Animator & Avatars")]
    public Animator animator;              // Player��Animator
    public GameObject defaultModel;        // ���̃��f���i�\�������j
    public GameObject[] avatarPrefabs;     // �؂�ւ��pPrefab
    public Avatar[] avatars;               // Avatar�����ւ��p�iHumanoid�j

    private GameObject currentAvatarObj;   // ���݂̐����A�o�^�[
    private int currentAvatarID = -1;      // ���݂�AvatarID
    private bool isTransformed = false;    // �ϐg����

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleAvatar();
        }
    }

    // �ϐg�^�����؂�ւ�
    void ToggleAvatar()
    {
        if (isTransformed)
        {
            // ���̎p�ɖ߂�
            if (currentAvatarObj != null)
            {
                Destroy(currentAvatarObj);
                currentAvatarObj = null;
            }

            if (defaultModel != null)
                defaultModel.SetActive(true);

            // Animator������Avatar�ɖ߂�
            if (currentAvatarID >= 0 && currentAvatarID < avatars.Length)
                animator.avatar = null; // �f�t�H���g�p�Ȃ�Avatar�Ȃ��ł�OK

            isTransformed = false;
        }
        else
        {
            // �ϐg����
            if (currentAvatarID < 0 && avatarPrefabs.Length > 0)
            {
                currentAvatarID = 0; // ������0�Ԗڂ̃A�o�^�[
            }

            if (currentAvatarID >= 0 && currentAvatarID < avatarPrefabs.Length)
            {
                // �O�̐����A�o�^�[���폜
                if (currentAvatarObj != null)
                    Destroy(currentAvatarObj);

                // �V�����A�o�^�[�𐶐�
                currentAvatarObj = Instantiate(avatarPrefabs[currentAvatarID], transform);
                currentAvatarObj.transform.localPosition = Vector3.zero;
                currentAvatarObj.transform.localRotation = Quaternion.identity;
                currentAvatarObj.transform.localScale = Vector3.one;

                // ���̃��f�����\��
                if (defaultModel != null)
                    defaultModel.SetActive(false);

                // Animator��Avatar��؂�ւ�
                animator.avatar = avatars[currentAvatarID];
            }

            isTransformed = true;
        }
    }

    // �ʂ�Avatar�ɐ؂�ւ������Ƃ��p
    public void SetAvatar(int id)
    {
        if (id >= 0 && id < avatarPrefabs.Length)
        {
            currentAvatarID = id;
            if (isTransformed)
            {
                // �ϐg���Ȃ炷���؂�ւ�
                ToggleAvatar();
                ToggleAvatar();
            }
        }
    }
}
