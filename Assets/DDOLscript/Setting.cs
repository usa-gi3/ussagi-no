using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField]
    //　設定画面UIのプレハブ
    private GameObject settingUIPrefab;
    //　設定画面UIのインスタンス
    private GameObject settingUIInstance;

    public void setting_botton()
    {
        //Debug.Log("=== Setting.setting_botton()が呼ばれました！ ===");

        // すでに開いていたら閉じる
        // settingUIInstanceの確認
        if (settingUIInstance != null)
        {
            Destroy(settingUIInstance);
            settingUIInstance = null;
            // ★ 設定画面を閉じる時にポーズメニューを再有効化
            EnablePauseMenu();
            return;
        }

        // Prefabの確認
        if (settingUIPrefab == null)
        {
            //Debug.LogError("settingUIPrefab が設定されていません");
            return;
        }

        // ★ 設定画面を開く前にポーズメニューを無効化
        DisablePauseMenu();

        // 設定画面をルートに生成
        settingUIInstance = Instantiate(settingUIPrefab);

        // Canvas の設定（PauseMenu より前に表示）
        Canvas canvas = settingUIInstance.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100; // PauseMenuより上に表示
        }

        //Debug.Log("設定画面を開きました");

        // === ここで BGMManager に通知して Slider を初期化 ===
        BGMManager bgmManager = FindObjectOfType<BGMManager>();
        if (bgmManager != null)
        {
            bgmManager.RegisterSettingUI(settingUIInstance);
        }
    }

    public void OnBackButton()
    {
        // 戻るボタンで非表示（削除）
        //Debug.Log("戻るボタンが押されました");
        Destroy(gameObject.transform.root.gameObject);
    }

    // ★ ポーズメニューを無効化する関数
    private void DisablePauseMenu()
    {
        PauseMenuUI pauseMenuUI = FindObjectOfType<PauseMenuUI>();
        if (pauseMenuUI != null)
        {
            pauseMenuUI.enabled = false; // スクリプト自体を無効化
        }
    }

    // ★ ポーズメニューを有効化する関数
    private void EnablePauseMenu()
    {
        PauseMenuUI pauseMenuUI = FindObjectOfType<PauseMenuUI>();
        if (pauseMenuUI != null)
        {
            pauseMenuUI.enabled = true; // スクリプトを有効化
        }
    }
}