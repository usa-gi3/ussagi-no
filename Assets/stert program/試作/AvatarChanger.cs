using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChanger : MonoBehaviour
{
    [Header("Animator & Avatars")]
    public Animator animator;              // 空のオブジェクトについてるAnimator
    public GameObject defaultModel;        // デフォルトの見た目（Animatorは削除しておく）
    public Avatar defaultAvatar;           // デフォルト用のAvatar
    public GameObject[] avatarPrefabs;     // 変身先の見た目（プレハブ）
    public Avatar[] avatars;               // 各変身先のAvatar（Humanoid）

    private GameObject currentAvatarObj;   // 今出してるアバター（実体）
    private int currentAvatarID = -1;      // 今選ばれてるアバター番号
    private bool isTransformed = false;    // 今変身してるかどうか

    void Update()
    {
        // Cキーで変身・解除
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleAvatar();
        }
    }

    // 変身 or 元に戻す
    void ToggleAvatar()
    {
        if (isTransformed)
        {
            // 元に戻す処理
            if (currentAvatarObj != null)
            {
                Destroy(currentAvatarObj); // 変身中のモデル削除
                currentAvatarObj = null;
            }

            defaultModel.SetActive(true);   // デフォルトの見た目を戻す
            animator.avatar = defaultAvatar;
            animator.Rebind();
            animator.Update(0);

            isTransformed = false;
        }
        else
        {
            // 変身する処理
            if (currentAvatarID < 0 || currentAvatarID >= avatarPrefabs.Length)
            {
                Debug.LogWarning("変身先が設定されてないよ！");
                return;
            }

            // 古いモデルがあれば消す
            if (currentAvatarObj != null)
                Destroy(currentAvatarObj);

            // 新しいアバターを出す

            currentAvatarObj = Instantiate(avatarPrefabs[currentAvatarID], transform);
            currentAvatarObj.transform.localPosition = Vector3.zero;
            currentAvatarObj.transform.localRotation = Quaternion.identity;
            currentAvatarObj.transform.localScale = Vector3.one;
            currentAvatarObj.tag = "Player"; // プレイヤータグをつける

            defaultModel.SetActive(false);   // デフォルトの見た目を消す

            animator.avatar = avatars[currentAvatarID];
            animator.Rebind();
            animator.Update(0);

            isTransformed = true;
        }
    }

    // 他のスクリプトから変身先を指定できるようにする
    public void SetAvatar(int id)
    {
        if (id >= 0 && id < avatarPrefabs.Length)
        {
            currentAvatarID = id;
            Debug.Log("変身先を " + avatarPrefabs[id].name + " に設定したよ");
        }
        else
        {
            Debug.LogWarning("そのIDのアバターは存在しないよ！");
        }
    }
}

