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
        if (settingUIInstance == null)
        {
            // インスタンスが存在しなければ生成して表示
            settingUIInstance = Instantiate(settingUIPrefab);

            // ボタンを探してOnClick登録
            Button backButton = settingUIInstance.transform.Find("Setting/Button").GetComponent<Button>();
            backButton.onClick.AddListener(OnBackButton);
        }
        else
        {
            // インスタンスが存在すれば削除（非表示）
            Destroy(settingUIInstance);
        }
    }

    public void OnBackButton()
    {
        // 戻るボタンで非表示（削除）
        if (settingUIInstance != null)
        {
            Destroy(settingUIInstance);
        }
    }
}