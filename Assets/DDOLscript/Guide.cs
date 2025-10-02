using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    [SerializeField]
    //�@������@���UI�̃v���n�u
    private GameObject guidePrefab;
    //�@������@���UI�̃C���X�^���X
    private GameObject guideInstance;

    public void guide_botton()
    {
        // ���łɊJ���Ă��������
        // guideInstance�̊m�F
        if (guideInstance != null)
        {
            Destroy(guideInstance);
            guideInstance = null;
            // �� ������@��ʂ���鎞�Ƀ|�[�Y���j���[���ėL����
            EnablePauseMenu();
            return;
        }

        // Prefab�̊m�F
        if (guidePrefab == null)
        {
            return;
        }

        // �� ������@��ʂ��J���O�Ƀ|�[�Y���j���[�𖳌���
        DisablePauseMenu();

        // ������@��ʂ����[�g�ɐ���
        guideInstance = Instantiate(guidePrefab);

        // Canvas �̐ݒ�iPauseMenu ���O�ɕ\���j
        Canvas canvas = guideInstance.GetComponent<Canvas>();
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
        //�Z�[�u
        //PlayerPrefs.Save();
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