using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuideMenuUI : MonoBehaviour
{
    private List<Selectable> uiElements = new List<Selectable>();
    private int currentSelectedIndex = 0;

    void Start()
    {
        // �q�K�w����{�^���擾
        Selectable[] elements = GetComponentsInChildren<Selectable>();
        uiElements.AddRange(elements);

        if (uiElements.Count > 0)
        {
            currentSelectedIndex = 0;
            EventSystem.current.SetSelectedGameObject(uiElements[0].gameObject);
        }
    }

    void Update()
    {
        HandleMenuNavigation();
    }

    void HandleMenuNavigation()
    {

        if (uiElements.Count == 0) return;

        // �{�^������������ꍇ�̂ݏ㉺�ړ�������
        if (uiElements.Count > 1)
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
        }
            

        // Enter / Space �� �{�^��������
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (uiElements[currentSelectedIndex] is Button button)
            {
                button.onClick.Invoke();
            }
        }
    }

    void UpdateSelection()
    {
        for (int i = 0; i < uiElements.Count; i++)
        {
            Selectable element = uiElements[i];

            //�{�^���̑I�𒆂͐F�ύX
            if (element is Button button)
            {
                ColorBlock colors = element.colors;
                if (i == currentSelectedIndex)
                {
                    colors.normalColor = new Color(0.85f, 0.85f, 0.85f, 1f); //�W���D�F
                    colors.selectedColor = new Color(0.85f, 0.85f, 0.85f, 1f);
                }
                else
                {
                    colors.normalColor = Color.white;
                    colors.selectedColor = Color.white;
                }
                button.colors = colors;
            }
        }
    }
}