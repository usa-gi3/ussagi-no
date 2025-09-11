using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject menuPanel; // ���j���[��UI�p�l��

    private bool isOpen = false;

    void Update()
    {
        // Escape�L�[��n���o�[�K�[�{�^���ŊJ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        isOpen = !isOpen;
        menuPanel.SetActive(isOpen);

        // ���j���[�J���Ă�Ԃ̓|�[�Y�������Ȃ�TimeScale���~�߂�
        Time.timeScale = isOpen ? 0f : 1f;
    }

    // UI�{�^������Ă�
    public void OnSelectCharacter(int id)
    {
        GameManager.Instance.ChangeCharacter(id);
    }
}
