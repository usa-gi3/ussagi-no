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
        // 子階層から全ボタン取得
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
        // ↑↓ で選択切り替え
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

        // Enter / Space → ボタンを押す
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (uiElements[currentSelectedIndex] is Button button)
            {
                button.onClick.Invoke();
            }
        }

        // ←→ でスライダー調整
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (uiElements[currentSelectedIndex] is Slider slider)
            {
                float step = 0.01f; // 音量調整幅
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

