using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pausemenuUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pausemenuUIInstance;
    // ボタンのリストを保持
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

        // メニューが開いているときのナビゲーション
        if (pausemenuUIInstance != null)
        {
            HandleMenuNavigation();
        }
    }

    void OpenPauseMenu()
    {
        //メニューを開いている間ポーズ
        pausemenuUIInstance = Instantiate(pausemenuUIPrefab);
        Time.timeScale = 0f;

        // すべてのボタンを取得
        menuButtons.Clear();
        Button[] buttons = pausemenuUIInstance.GetComponentsInChildren<Button>();
        menuButtons.AddRange(buttons);

        // どんなボタンがあるか確認
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
                
                // OnClickイベントの詳細情報を表示
                for (int i = 0; i < selectedButton.onClick.GetPersistentEventCount(); i++)

                // ★ 設定ボタンの特別処理を削除して、onClick.Invoke()のみ実行
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
                // 選択されたボタンの色を変更
                colors.normalColor = new Color(0.85f, 0.85f, 0.85f, 1f); //淡い灰色
                colors.selectedColor = new Color(0.85f, 0.85f, 0.85f, 1f);
            }
            else
            {
                // 通常のボタンの色
                colors.normalColor = Color.white;
                colors.selectedColor = Color.white;
            }

            menuButtons[i].colors = colors;
        }

        // EventSystemでも選択状態を更新
        EventSystem.current.SetSelectedGameObject(menuButtons[currentSelectedIndex].gameObject);
    }

    // UIボタンから呼ぶ
    //着せ替え用
    public void OnSelectCharacter(int id)
    {
        GameManager.Instance.ChangeCharacter(id);
    }
}
