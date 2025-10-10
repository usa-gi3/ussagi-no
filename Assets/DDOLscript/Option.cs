using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField]
    //�@�N���W�b�g���UI�̃v���n�u
    private GameObject optionPrefab;
    //�@�N���W�b�g���UI�̃C���X�^���X
    private GameObject optionInstance;

    public void option_botton()
    {
        // ���łɊJ���Ă��������
        // optionInstance�̊m�F
        if (optionInstance != null)
        {
            Destroy(optionInstance);
            optionInstance = null;
            // �� ������@��ʂ���鎞�Ƀ|�[�Y���j���[���ėL����
            EnablePauseMenu();
            return;
        }

        // Prefab�̊m�F
        if (optionPrefab == null)
        {
            return;
        }

        // �� ������@��ʂ��J���O�Ƀ|�[�Y���j���[�𖳌���
        DisablePauseMenu();

        // ������@��ʂ����[�g�ɐ���
        optionInstance = Instantiate(optionPrefab);

        // Canvas �̐ݒ�iPauseMenu ���O�ɕ\���j
        Canvas canvas = optionInstance.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100; // PauseMenu����ɕ\��
        }
    }

    public void OnBackButton()
    {
        // �߂�{�^���Ŕ�\���i�폜�j
        // �� ���j���[���ėL����
        EnablePauseMenu();
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
