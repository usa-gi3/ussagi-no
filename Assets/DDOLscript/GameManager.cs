using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private List<GameObject> characterPrefabs;
    public GameObject currentCharacter;
    private int currentCharacterId = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // キャラ生成（初期スポーン用）
    public void SpawnCharacter(Vector3 position, Quaternion rotation)
    {
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }
        currentCharacter = Instantiate(characterPrefabs[currentCharacterId], position, rotation);
    }

    // キャラ変更（メニューから呼ぶ）
    public void ChangeCharacter(int id)
    {
        currentCharacterId = id;

        if (currentCharacter != null)
        {
            Vector3 pos = currentCharacter.transform.position;
            Quaternion rot = currentCharacter.transform.rotation;
            SpawnCharacter(pos, rot);
        }
    }
}
