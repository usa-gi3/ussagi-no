using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public Transform spawnPoint; //�X�|�[���n�_

    void Start()
    {
        if (GameManager.Instance.currentCharacter == null)
        {
            GameManager.Instance.SpawnCharacter(spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            // �����̃L���������X�|�[���n�_�Ɉړ�
            GameManager.Instance.currentCharacter.transform.position = spawnPoint.position;
            GameManager.Instance.currentCharacter.transform.rotation = spawnPoint.rotation;
        }
    }
}
