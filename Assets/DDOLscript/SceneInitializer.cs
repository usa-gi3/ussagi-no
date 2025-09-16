using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    //[SerializeField]
    //private Transform spawnPoint; //�X�|�[���n�_

    void Start()
    {
        // �V�[������SpawnPoint��T��
        SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();
        if (spawnPoint == null)
        {
            Debug.LogWarning("SpawnPoint���V�[���ɂ���܂���I");
            return;
        }

        // ���łɃL���������݂���Ȃ�ʒu�����킹��
        if (GameManager.Instance.currentCharacter != null)
        {
            GameManager.Instance.currentCharacter.transform.position = spawnPoint.transform.position;
            GameManager.Instance.currentCharacter.transform.rotation = spawnPoint.transform.rotation;
        }
        else
        {
            // �L���������Ȃ��Ȃ�V����Spawn
            GameManager.Instance.SpawnCharacter(spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }
}
