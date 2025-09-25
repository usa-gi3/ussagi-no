using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingMenuUI : MonoBehaviour
{
    private List<Selectable> uiElements = new List<Selectable>();
    private int currentSelectedIndex = 0;

    void Start()
    {
        // �q�K�w����S�{�^���擾
        Selectable[] elements = GetComponentsInChildren<Selectable>();
        uiElements.AddRange(elements);

        if (uiElements.Count > 0)
        {
            currentSelectedIndex = 0;
            UpdateSelection();
        }
    }

    void Update()
    {
        HandleMenuNavigation();
    }

    void HandleMenuNavigation()
    {
        // ���� �őI��؂�ւ�
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            currentSelectedIndex = (currentSelectedIndex - 1 + uiElements.Count) % uiElements.Count;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            currentSelectedIndex = (currentSelectedIndex + 1) % uiElements.Count;
            UpdateSelection();
        }

        // Enter / Space �� �{�^��������
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (uiElements[currentSelectedIndex] is Button button)
            {
                button.onClick.Invoke();
            }
        }

        // ���� �ŃX���C�_�[����
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (uiElements[currentSelectedIndex] is Slider slider)
            {
                float step = 0.01f; // ���ʒ�����
                if (Input.GetKey(KeyCode.LeftArrow))
                    slider.value -= step;
                if (Input.GetKey(KeyCode.RightArrow))
                    slider.value += step;
            }
        }
    }

    void UpdateSelection()
    {
        for (int i = 0; i < uiElements.Count; i++)
        {
            if (uiElements[i] is Button button)
            {
                ColorBlock colors = button.colors;
                if (i == currentSelectedIndex)
                {
                    colors.normalColor = Color.yellow;
                    colors.selectedColor = Color.yellow;
                }
                else
                {
                    colors.normalColor = Color.white;
                    colors.selectedColor = Color.white;
                }
                button.colors = colors;
            }
        }

        EventSystem.current.SetSelectedGameObject(uiElements[currentSelectedIndex].gameObject);
    }
}

