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
        Debug.Log("=== Setting.setting_botton()が呼ばれました！ ===");

        // すでに開いていたら閉じる
        // settingUIInstanceの確認
        if (settingUIInstance != null)
        {
            Destroy(settingUIInstance);
            settingUIInstance = null;
            return;
        }

        // Prefabの確認
        if (settingUIPrefab == null)
        {
            Debug.LogError("settingUIPrefab が設定されていません");
            return;
        }

        // PausemenuUI 内の Canvas を探す
        Canvas parentCanvas = GetComponentInChildren<Canvas>();
        if (parentCanvas == null)
        {
            Debug.LogError("PausemenuUI 内に Canvas が見つかりません");
            return;
        }

        // 設定画面は独自の Canvas を持っているので、ルートに直接生成する
        settingUIInstance = Instantiate(settingUIPrefab);

        // 他のUIより手前に出すための設定
        Canvas canvas = settingUIInstance.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100; // PauseMenu より手前に表示
        }

        Debug.Log("設定画面を開きました");
    }

    // デバッグ用：オブジェクトの階層を表示
    /*void LogHierarchy(Transform parent, int depth)
    {
        string indent = new string(' ', depth * 2);
        GameObject obj = parent.gameObject;
        Debug.Log($"{indent}- {obj.name} (Active: {obj.activeInHierarchy})");

        for (int i = 0; i < parent.childCount; i++)
        {
            LogHierarchy(parent.GetChild(i), depth + 1);
        }
    }*/

    public void OnBackButton()
    {
        // 戻るボタンで非表示（削除）
        Debug.Log("戻るボタンが押されました");
        if (settingUIInstance != null)
        {
            Destroy(settingUIInstance);
            settingUIInstance = null;
        }
    }
}