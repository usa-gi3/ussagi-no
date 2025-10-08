
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    [SerializeField] private GameObject talkMark; // ��b�\�}�[�N
    [SerializeField] private Camera mainCamera;   // ���C���J����

    void Start()
    {
        if (talkMark != null) talkMark.SetActive(false);//�}�[�N���\����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (talkMark != null) talkMark.SetActive(true); // �͈͂ɓ�������}�[�N�\��
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (talkMark != null) talkMark.SetActive(false); // �͈͂���o�����\��
        }
    }
    private void LateUpdate()
    {
        // �}�[�N���J�����̕����Ɍ�����
        if (talkMark != null && talkMark.activeSelf)
        {
            talkMark.transform.LookAt(talkMark.transform.position + mainCamera.transform.forward);
        }
    }
}
