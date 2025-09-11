using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject menuPanel; // メニューのUIパネル

    private bool isOpen = false;

    void Update()
    {
        // Escapeキーやハンバーガーボタンで開閉
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        isOpen = !isOpen;
        menuPanel.SetActive(isOpen);

        // メニュー開いてる間はポーズしたいならTimeScaleを止める
        Time.timeScale = isOpen ? 0f : 1f;
    }

    // UIボタンから呼ぶ
    public void OnSelectCharacter(int id)
    {
        GameManager.Instance.ChangeCharacter(id);
    }
}
