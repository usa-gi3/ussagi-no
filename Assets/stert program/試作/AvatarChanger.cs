using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChanger : MonoBehaviour
{
    [Header("Animator & Avatars")]
    public Animator animator;              // 空オブジェクトについているAnimator
    public GameObject defaultModel;        // デフォルトの見た目（Animatorは削除しておく）
    public Avatar defaultAvatar;           // defaultModelのAvatar
    public GameObject[] avatarPrefabs;     // 切り替え用の見た目
    public Avatar[] avatars;               // 各アバターのAvatar（Humanoid）

    private GameObject currentAvatarObj;
    private int currentAvatarID = -1;
    private bool isTransformed = false;

    void Update()
    {
        //Cで変身
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleAvatar();
        }
    }

    void ToggleAvatar()
    {
        //変身を解除して元に戻す処理
        if (isTransformed)
        {
            // 現在のアバターを削除
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
            // 変身
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
