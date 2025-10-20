using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public AudioClip menuSE;
    public AudioClip jumpSE;
    public AudioClip sceneChangeMoveSE; // �� �V�[���؂�ւ��p��ǉ�
    public AudioClip sceneChangeBackSE;
    //public AudioClip doorSE;
    //public AudioClip dressupSE;

    AudioSource audioSource;

    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ���j���[�J����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.PlayOneShot(menuSE);
        }

        // �W�����v��
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
