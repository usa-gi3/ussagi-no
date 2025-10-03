using UnityEngine;

public class AvatarSpot : MonoBehaviour
{
    public int avatarID; // ���̃X�|�b�g�Ŏg����A�o�^�[
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
