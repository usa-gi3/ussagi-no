using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �V�[����؂�ւ��Ă��j������Ȃ�
        }
        else
        {
            Destroy(gameObject); // 2�ڂ���������Ȃ��悤�ɔj��
        }
    }
}

