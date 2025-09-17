using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    //[SerializeField]
    //private Transform spawnPoint; //スポーン地点

    void Start()
    {
        // シーン内のSpawnPointを探す
        SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();
        if (spawnPoint == null)
        {
            Debug.LogWarning("SpawnPointがシーンにありません！");
            return;
        }

        // すでにキャラが存在するなら位置を合わせる
        if (GameManager.Instance.currentCharacter != null)
        {
            GameManager.Instance.currentCharacter.transform.position = spawnPoint.transform.position;
            GameManager.Instance.currentCharacter.transform.rotation = spawnPoint.transform.rotation;
        }
        else
        {
            // キャラがいないなら新しくSpawn
            GameManager.Instance.SpawnCharacter(spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }
}
