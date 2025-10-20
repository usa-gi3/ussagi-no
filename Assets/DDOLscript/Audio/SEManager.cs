using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public AudioClip menuSE;
    public AudioClip jumpSE;
    public AudioClip sceneChangeMoveSE; // ← シーン切り替え用を追加
    public AudioClip sceneChangeBackSE;
    //public AudioClip doorSE;
    //public AudioClip dressupSE;

    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // メニュー開く音
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.PlayOneShot(menuSE);
        }

        // ジャンプ音
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.PlayOneShot(jumpSE);
        }
    }

    public void PlaysceneChangeMoveSE()
    {
        audioSource.PlayOneShot(sceneChangeMoveSE);
    }
    public void PlaysceneChangeBackSE()
    {
        audioSource.PlayOneShot(sceneChangeBackSE);
    }
}
