using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSE : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ��
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
        }
    }
}
