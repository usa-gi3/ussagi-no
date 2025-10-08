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

        // �ǂ�ȃ{�^�������邩�m�F
        foreach (Button btn in buttons)

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
            
            if (currentSelectedIndex < menuButtons.Count)
            {
                Button selectedButton = menuButtons[currentSelectedIndex];
                
                // OnClick�C�x���g�̏ڍ׏���\��
                for (int i = 0; i < selectedButton.onClick.GetPersistentEventCount(); i++)

                // �� �ݒ�{�^���̓��ʏ������폜���āAonClick.Invoke()�̂ݎ��s
                selectedButton.onClick.Invoke();
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
                colors.normalColor = new Color(0.85f, 0.85f, 0.85f, 1f); //�W���D�F
                colors.selectedColor = new Color(0.85f, 0.85f, 0.85f, 1f);
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
    }

    // UI�{�^������Ă�
    //�����ւ��p
    public void OnSelectCharacter(int id)
    {
        GameManager.Instance.ChangeCharacter(id);
    }
}
