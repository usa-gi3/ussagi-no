using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenuUI : MonoBehaviour
{

    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject pausemenuUIPrefab;
    //�@�|�[�YUI�̃C���X�^���X
    private GameObject pausemenuUIInstance;
    // �{�^���̃��X�g��ێ�
    private List<Button> menuButtons = new List<Button>();
    private int currentSelectedIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pausemenuUIInstance == null)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
        }

        // ���j���[���J���Ă���Ƃ��̃i�r�Q�[�V����
        if (pausemenuUIInstance != null)
        {
            HandleMenuNavigation();
        }
    }

    void OpenPauseMenu()
    {
        //���j���[���J���Ă���ԃ|�[�Y
        pausemenuUIInstance = Instantiate(pausemenuUIPrefab);
        Time.timeScale = 0f;

        // ���ׂẴ{�^�����擾
        menuButtons.Clear();
        Button[] buttons = pausemenuUIInstance.GetComponentsInChildren<Button>();
        menuButtons.AddRange(buttons);

        // �� �f�o�b�O�ǉ�: �ǂ�ȃ{�^�������邩�m�F
        Debug.Log($"���������{�^���̐�: {buttons.Length}");
        foreach (Button btn in buttons)
        {
            Debug.Log($"�{�^����: {btn.name}");
            Debug.Log($"  OnClick�C�x���g��: {btn.onClick.GetPersistentEventCount()}");
        }

        if (menuButtons.Count > 0)
        {
            currentSelectedIndex = 0;
            UpdateButtonSelection();
        }
    }

    void ClosePauseMenu()
    {
        Destroy(pausemenuUIInstance);
        Time.timeScale = 1f;
        menuButtons.Clear();
    }

    void HandleMenuNavigation()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            currentSelectedIndex = (currentSelectedIndex - 1 + menuButtons.Count) % menuButtons.Count;
            UpdateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            currentSelectedIndex = (currentSelectedIndex + 1) % menuButtons.Count;
            UpdateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"�G���^�[�L�[��������܂����I���݂̃C���f�b�N�X: {currentSelectedIndex}");

            if (currentSelectedIndex < menuButtons.Count)
            {
                Button selectedButton = menuButtons[currentSelectedIndex];
                Debug.Log($"�I�����ꂽ�{�^��: {selectedButton.name}");
                Debug.Log($"OnClick�C�x���g��: {selectedButton.onClick.GetPersistentEventCount()}");

                // OnClick�C�x���g�̏ڍ׏���\��
                for (int i = 0; i < selectedButton.onClick.GetPersistentEventCount(); i++)
                {
                    Debug.Log($"  �C�x���g{i}: {selectedButton.onClick.GetPersistentTarget(i)?.name}.{selectedButton.onClick.GetPersistentMethodName(i)}");
                }

                // �� �ݒ�{�^���̓��ʏ������폜���āAonClick.Invoke()�̂ݎ��s
                Debug.Log("onClick.Invoke()�����s���܂�");
                selectedButton.onClick.Invoke();
                Debug.Log("onClick.Invoke()����");
            }
            else
            {
                Debug.LogError("�I���C���f�b�N�X���͈͊O�ł�");
            }
        }
    }

    void UpdateButtonSelection()
    {
        for (int i = 0; i < menuButtons.Count; i++)
        {
            ColorBlock colors = menuButtons[i].colors;

            if (i == currentSelectedIndex)
            {
                // �I�����ꂽ�{�^���̐F��ύX
                colors.normalColor = Color.yellow;
                colors.selectedColor = Color.yellow;
            }
            else
            {
                // �ʏ�̃{�^���̐F
                colors.normalColor = Color.white;
                colors.selectedColor = Color.white;
            }

            menuButtons[i].colors = colors;
        }

        // EventSystem�ł��I����Ԃ��X�V
        EventSystem.current.SetSelectedGameObject(menuButtons[currentSelectedIndex].gameObject);

        // �� �f�o�b�O�ǉ�: ���ݑI������Ă���{�^����\��
        Debug.Log($"���ݑI��: {menuButtons[currentSelectedIndex].name} (�C���f�b�N�X: {currentSelectedIndex})");
    }

    // UI�{�^������Ă�
    //�����ւ��p
    public void OnSelectCharacter(int id)
    {
        GameManager.Instance.ChangeCharacter(id);
    }
}
