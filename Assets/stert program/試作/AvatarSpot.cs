using UnityEngine;

public class AvatarSpot : MonoBehaviour
{
    public int avatarID; // このスポットで使えるアバター
    private AvatarChanger changer;

    void Start()
    {
        changer = FindObjectOfType<AvatarChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            changer.SetAvatar(avatarID);
        }
    }
}
