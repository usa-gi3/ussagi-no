using UnityEngine;

public class PositionMemory : MonoBehaviour
{
    public static PositionMemory Instance; // �� ���ꂪ�K�v�I

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
            Destroy(gameObject); // �d����h��
        }
    }

    public static void SavePosition(Vector3 pos)
    {
        returnPosition = pos;
        hasSavedPosition = true;
    }
}