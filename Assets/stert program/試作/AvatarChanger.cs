using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChanger : MonoBehaviour
{
    [Header("Animator & Avatars")]
    public Animator animator;              // PlayerのAnimator
    public GameObject defaultModel;        // 元のモデル（表示だけ）
    public GameObject[] avatarPrefabs;     // 切り替え用Prefab
    public Avatar[] avatars;               // Avatar差し替え用（Humanoid）

    private GameObject currentAvatarObj;   // 現在の生成アバター
    private int currentAvatarID = -1;      // 現在のAvatarID
    private bool isTransformed = false;    // 変身中か

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleAvatar();
        }
    }

    // 変身／解除切り替え
    void ToggleAvatar()
    {
        if (isTransformed)
        {
            // 元の姿に戻す
            if (currentAvatarObj != null)
            {
                Destroy(currentAvatarObj);
                currentAvatarObj = null;
            }

            if (defaultModel != null)
                defaultModel.SetActive(true);

            // Animatorを元のAvatarに戻す
            if (currentAvatarID >= 0 && currentAvatarID < avatars.Length)
                animator.avatar = null; // デフォルト姿ならAvatarなしでもOK

            isTransformed = false;
        }
        else
        {
            // 変身する
            if (currentAvatarID < 0 && avatarPrefabs.Length > 0)
            {
                currentAvatarID = 0; // 初期は0番目のアバター
            }

            if (currentAvatarID >= 0 && currentAvatarID < avatarPrefabs.Length)
            {
                // 前の生成アバターを削除
                if (currentAvatarObj != null)
                    Destroy(currentAvatarObj);

                // 新しいアバターを生成
                currentAvatarObj = Instantiate(avatarPrefabs[currentAvatarID], transform);
                currentAvatarObj.transform.localPosition = Vector3.zero;
                currentAvatarObj.transform.localRotation = Quaternion.identity;
                currentAvatarObj.transform.localScale = Vector3.one;

                // 元のモデルを非表示
                if (defaultModel != null)
                    defaultModel.SetActive(false);

                // AnimatorのAvatarを切り替え
                animator.avatar = avatars[currentAvatarID];
            }

            isTransformed = true;
        }
    }

    // 別のAvatarに切り替えたいとき用
    public void SetAvatar(int id)
    {
        if (id >= 0 && id < avatarPrefabs.Length)
        {
            currentAvatarID = id;
            if (isTransformed)
            {
                // 変身中ならすぐ切り替え
                ToggleAvatar();
                ToggleAvatar();
            }
        }
    }
}
