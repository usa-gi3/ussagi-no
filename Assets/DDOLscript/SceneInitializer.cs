using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public Transform spawnPoint; //スポーン地点

    void Start()
    {
        if (GameManager.Instance.currentCharacter == null)
        {
            GameManager.Instance.SpawnCharacter(spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            // 既存のキャラをリスポーン地点に移動
            GameManager.Instance.currentCharacter.transform.position = spawnPoint.position;
            GameManager.Instance.currentCharacter.transform.rotation = spawnPoint.rotation;
        }
    }
}
