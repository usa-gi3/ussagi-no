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

        // ★ デバッグ追加: どんなボタンがあるか確認
        Debug.Log($"見つかったボタンの数: {buttons.Length}");
        foreach (Button btn in buttons)
        {
            Debug.Log($"ボタン名: {btn.name}");
            Debug.Log($"  OnClickイベント数: {btn.onClick.GetPersistentEventCount()}");
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
            Debug.Log($"エンターキーが押されました！現在のインデックス: {currentSelectedIndex}");

            if (currentSelectedIndex < menuButtons.Count)
            {
                Button selectedButton = menuButtons[currentSelectedIndex];
                Debug.Log($"選択されたボタン: {selectedButton.name}");
                Debug.Log($"OnClickイベント数: {selectedButton.onClick.GetPersistentEventCount()}");

                // OnClickイベントの詳細情報を表示
                for (int i = 0; i < selectedButton.onClick.GetPersistentEventCount(); i++)
                {
                    Debug.Log($"  イベント{i}: {selectedButton.onClick.GetPersistentTarget(i)?.name}.{selectedButton.onClick.GetPersistentMethodName(i)}");
                }

                // ★ 設定ボタンの特別処理を削除して、onClick.Invoke()のみ実行
                Debug.Log("onClick.Invoke()を実行します");
                selectedButton.onClick.Invoke();
                Debug.Log("onClick.Invoke()完了");
            }
            else
            {
                Debug.LogError("選択インデックスが範囲外です");
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
                colors.normalColor = Color.yellow;
                colors.selectedColor = Color.yellow;
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

        // ★ デバッグ追加: 現在選択されているボタンを表示
        Debug.Log($"現在選択中: {menuButtons[currentSelectedIndex].name} (インデックス: {currentSelectedIndex})");
    }

    // UIボタンから呼ぶ
    //着せ替え用
    public void OnSelectCharacter(int id)
    {
        GameManager.Instance.ChangeCharacter(id);
    }
}
