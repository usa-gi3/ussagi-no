using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    [SerializeField]
    //　操作方法画面UIのプレハブ
    private GameObject guidePrefab;
    //　操作方法画面UIのインスタンス
    private GameObject guideInstance;

    public void guide_botton()
    {
        // すでに開いていたら閉じる
        // guideInstanceの確認
        if (guideInstance != null)
        {
            Destroy(guideInstance);
            guideInstance = null;
            // ★ 操作方法画面を閉じる時にポーズメニューを再有効化
            EnablePauseMenu();
            return;
        }

        // Prefabの確認
        if (guidePrefab == null)
        {
            return;
        }

        // ★ 操作方法画面を開く前にポーズメニューを無効化
        DisablePauseMenu();

        // 操作方法画面をルートに生成
        guideInstance = Instantiate(guidePrefab);

        // Canvas の設定（PauseMenu より前に表示）
        Canvas canvas = guideInstance.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100; // PauseMenuより上に表示
        }
    }

    public void OnBackButton()
    {
        // 戻るボタンで非表示（削除）
        // ★ メニューを再有効化
        EnablePauseMenu();
        //セーブ
        //PlayerPrefs.Save();
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