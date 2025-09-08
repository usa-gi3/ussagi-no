using UnityEngine;

public class PositionMemory : MonoBehaviour
{
    public static PositionMemory Instance; // ← これが必要！

    public static Vector3 returnPosition;
    public static bool hasSavedPosition = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 重複を防ぐ
        }
    }

    public static void SavePosition(Vector3 pos)
    {
        returnPosition = pos;
        hasSavedPosition = true;
    }
}