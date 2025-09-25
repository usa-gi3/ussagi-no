using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField]
    //�@�ݒ���UI�̃v���n�u
    private GameObject settingUIPrefab;
    //�@�ݒ���UI�̃C���X�^���X
    private GameObject settingUIInstance;

    public void setting_botton()
    {
        Debug.Log("=== Setting.setting_botton()���Ă΂�܂����I ===");

        // ���łɊJ���Ă��������
        // settingUIInstance�̊m�F
        if (settingUIInstance != null)
        {
            Destroy(settingUIInstance);
            settingUIInstance = null;
            return;
        }

        // Prefab�̊m�F
        if (settingUIPrefab == null)
        {
            Debug.LogError("settingUIPrefab ���ݒ肳��Ă��܂���");
            return;
        }

        // PausemenuUI ���� Canvas ��T��
        Canvas parentCanvas = GetComponentInChildren<Canvas>();
        if (parentCanvas == null)
        {
            Debug.LogError("PausemenuUI ���� Canvas ��������܂���");
            return;
        }

        // �ݒ��ʂ͓Ǝ��� Canvas �������Ă���̂ŁA���[�g�ɒ��ڐ�������
        settingUIInstance = Instantiate(settingUIPrefab);

        // ����UI����O�ɏo�����߂̐ݒ�
        Canvas canvas = settingUIInstance.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100; // PauseMenu ����O�ɕ\��
        }

        Debug.Log("�ݒ��ʂ��J���܂���");
    }

    // �f�o�b�O�p�F�I�u�W�F�N�g�̊K�w��\��
    /*void LogHierarchy(Transform parent, int depth)
    {
        string indent = new string(' ', depth * 2);
        GameObject obj = parent.gameObject;
        Debug.Log($"{indent}- {obj.name} (Active: {obj.activeInHierarchy})");

        for (int i = 0; i < parent.childCount; i++)
        {
            LogHierarchy(parent.GetChild(i), depth + 1);
        }
    }*/

    public void OnBackButton()
    {
        // �߂�{�^���Ŕ�\���i�폜�j
        Debug.Log("�߂�{�^����������܂���");
        if (settingUIInstance != null)
        {
            Destroy(settingUIInstance);
            settingUIInstance = null;
        }
    }
}