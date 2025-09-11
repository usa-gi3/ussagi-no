using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookrabbity : MonoBehaviour
{
    public Transform player;   // �v���C���[���C���X�y�N�^�[�ɃZ�b�g
    public float heightOffset = 1.5f; // �v���C���[�̏����������

    void LateUpdate()
    {
        if (player == null) return;

        // �v���C���[�̈ʒu���^�[�Q�b�g�ɂ���
        Vector3 target = new Vector3(player.position.x,
                                     player.position.y + heightOffset,
                                     player.position.z);

        // �J�����̈ʒu�͕ς����ɁA�v���C���[�̕���������
        transform.LookAt(target);
    }
}
