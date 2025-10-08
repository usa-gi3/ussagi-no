using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChanger : MonoBehaviour
{
    [Header("Animator & Avatars")]
    public Animator animator;              // ��I�u�W�F�N�g�ɂ��Ă���Animator
    public GameObject defaultModel;        // �f�t�H���g�̌����ځiAnimator�͍폜���Ă����j
    public Avatar defaultAvatar;           // defaultModel��Avatar
    public GameObject[] avatarPrefabs;     // �؂�ւ��p�̌�����
    public Avatar[] avatars;               // �e�A�o�^�[��Avatar�iHumanoid�j

    private GameObject currentAvatarObj;
    private int currentAvatarID = -1;
    private bool isTransformed = false;

    void Update()
    {
        //C�ŕϐg
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleAvatar();
        }
    }

    void ToggleAvatar()
    {
        //�ϐg���������Č��ɖ߂�����
        if (isTransformed)
        {
            // ���݂̃A�o�^�[���폜
            if (currentAvatarObj != null)
            {
                Destroy(currentAvatarObj);
                currentAvatarObj = null;
            }

            if (defaultModel != null)
                defaultModel.SetActive(true);

            animator.avatar = defaultAvatar;
            animator.Rebind();
            animator.Update(0);

            isTransformed = false;
        }
        else
        {
            // �ϐg
            if (currentAvatarID < 0 && avatarPrefabs.Length > 0)
                currentAvatarID = 0;

            if (currentAvatarID >= 0 && currentAvatarID < avatarPrefabs.Length)
            {
                if (currentAvatarObj != null)
                    Destroy(currentAvatarObj);

                currentAvatarObj = Instantiate(avatarPrefabs[currentAvatarID], transform);
                currentAvatarObj.transform.localPosition = Vector3.zero;
                currentAvatarObj.transform.localRotation = Quaternion.identity;
                currentAvatarObj.transform.localScale = Vector3.one;

                currentAvatarObj.tag = "Player";

                if (defaultModel != null)
                    defaultModel.SetActive(false);

                animator.avatar = avatars[currentAvatarID];
                animator.Rebind();
                animator.Update(0);
            }

            isTransformed = true;
        }
    }
}
