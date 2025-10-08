using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    [SerializeField] private GameObject EnterMark; // ��b�\�}�[�N
    [SerializeField] private Camera mainCamera;   // ���C���J����

    void Start()
    {
        if (EnterMark != null) EnterMark.SetActive(false);//�}�[�N���\����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (EnterMark != null) EnterMark.SetActive(true); // �͈͂ɓ�������}�[�N�\��
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (EnterMark != null) EnterMark.SetActive(false); // �͈͂���o�����\��
        }
    }
    private void LateUpdate()
    {
        // �}�[�N���J�����̕����Ɍ�����
        if (EnterMark != null && EnterMark.activeSelf)
        {
            EnterMark.transform.LookAt(EnterMark.transform.position + mainCamera.transform.forward);
        }
    }
}
