using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("�L������Prefab�ꗗ")]
    public GameObject[] characterPrefabs;

    [HideInInspector] public GameObject currentCharacter;
    private int currentId = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �L���������i�����X�|�[���p�j
    public void SpawnCharacter(Vector3 position, Quaternion rotation)
    {
        if (currentCharacter != null)
            Destroy(currentCharacter);

        currentCharacter = Instantiate(characterPrefabs[currentId], position, rotation);
        DontDestroyOnLoad(currentCharacter);
    }

    // �L�����ύX�i���j���[����Ăԁj
    public void ChangeCharacter(int id)
    {
        currentId = id;

        if (currentCharacter != null)
        {
            Vector3 pos = currentCharacter.transform.position;
            Quaternion rot = currentCharacter.transform.rotation;
            Destroy(currentCharacter);

            currentCharacter = Instantiate(characterPrefabs[currentId], pos, rot);
            DontDestroyOnLoad(currentCharacter);
        }
    }
}
