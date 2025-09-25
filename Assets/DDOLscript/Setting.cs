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
        //Debug.Log("=== Setting.setting_botton()���Ă΂�܂����I ===");

        // ���łɊJ���Ă��������
        // settingUIInstance�̊m�F
        if (settingUIInstance != null)
        {
            Destroy(settingUIInstance);
            settingUIInstance = null;
            // �� �ݒ��ʂ���鎞�Ƀ|�[�Y���j���[���ėL����
            EnablePauseMenu();
            return;
        }

        // Prefab�̊m�F
        if (settingUIPrefab == null)
        {
            //Debug.LogError("settingUIPrefab ���ݒ肳��Ă��܂���");
            return;
        }

        // �� �ݒ��ʂ��J���O�Ƀ|�[�Y���j���[�𖳌���
        DisablePauseMenu();

        // �ݒ��ʂ����[�g�ɐ���
        settingUIInstance = Instantiate(settingUIPrefab);

        // Canvas �̐ݒ�iPauseMenu ���O�ɕ\���j
        Canvas canvas = settingUIInstance.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100; // PauseMenu����ɕ\��
        }

        //Debug.Log("�ݒ��ʂ��J���܂���");

        // === ������ BGMManager �ɒʒm���� Slider �������� ===
        BGMManager bgmManager = FindObjectOfType<BGMManager>();
        if (bgmManager != null)
        {
            bgmManager.RegisterSettingUI(settingUIInstance);
        }
    }

    public void OnBackButton()
    {
        // �߂�{�^���Ŕ�\���i�폜�j
        //Debug.Log("�߂�{�^����������܂���");
        Destroy(gameObject.transform.root.gameObject);
    }

    // �� �|�[�Y���j���[�𖳌�������֐�
    private void DisablePauseMenu()
    {
        PauseMenuUI pauseMenuUI = FindObjectOfType<PauseMenuUI>();
        if (pauseMenuUI != null)
        {
            pauseMenuUI.enabled = false; // �X�N���v�g���̂𖳌���
        }
    }

    // �� �|�[�Y���j���[��L��������֐�
    private void EnablePauseMenu()
    {
        PauseMenuUI pauseMenuUI = FindObjectOfType<PauseMenuUI>();
        if (pauseMenuUI != null)
        {
            pauseMenuUI.enabled = true; // �X�N���v�g��L����
        }
    }
}