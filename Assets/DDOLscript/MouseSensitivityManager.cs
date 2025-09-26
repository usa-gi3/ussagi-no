using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityManager : MonoBehaviour
{
    [SerializeField] private See seeScript; // 感度処理しているスクリプトを参照
    [SerializeField] private float defaultXSensitivity = 0.5f; // ★ デフォルト値を設定
    [SerializeField] private float defaultYSensitivity = 0.5f; // ★ デフォルト値を設定
    private Slider xSlider;
    private Slider ySlider;

    // Setting.cs から呼ばれる
    public void RegisterSettingUI(GameObject settingUIInstance)
    {
        Debug.Log("RegisterSettingUI が呼ばれました");

        // SettingUI 内のスライダーを全部探す
        Slider[] sliders = settingUIInstance.GetComponentsInChildren<Slider>(true);
        Debug.Log($"見つかったスライダー数: {sliders.Length}");

        foreach (var slider in sliders)
        {
            Debug.Log($"スライダー名: {slider.name}");

            if (slider.name == "xSlider")
            {
                xSlider = slider;
                xSlider.value = PlayerPrefs.GetFloat("X_Sensitivity", seeScript.Xsensityvity);
                xSlider.onValueChanged.RemoveAllListeners();
                xSlider.onValueChanged.AddListener(SetX);
                Debug.Log($"Xスライダー設定完了: {xSlider.value}");
            }
            else if (slider.name == "ySlider")
            {
                ySlider = slider;
                ySlider.value = PlayerPrefs.GetFloat("Y_Sensitivity", seeScript.Ysensityvity);
                ySlider.onValueChanged.RemoveAllListeners();
                ySlider.onValueChanged.AddListener(SetY);
                Debug.Log($"Yスライダー設定完了: {ySlider.value}");
            }
        }

        // ★ リセットボタンも探して設定
        Button[] buttons = settingUIInstance.GetComponentsInChildren<Button>(true);
        foreach (var button in buttons)
        {
            if (button.name == "ResetButton") // リセットボタンの名前
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(ResetToDefault);
                Debug.Log("リセットボタン設定完了");
            }
        }
    }

    // ★ デフォルト値にリセットする関数
    public void ResetToDefault()
    {
        Debug.Log("感度をデフォルト値にリセット");

        // スライダーの値を更新（これによりSetX、SetYも呼ばれる）
        if (xSlider != null)
        {
            xSlider.value = defaultXSensitivity;
        }
        if (ySlider != null)
        {
            ySlider.value = defaultYSensitivity;
        }

        // 直接値も更新（念のため）
        seeScript.Xsensityvity = defaultXSensitivity;
        seeScript.Ysensityvity = defaultYSensitivity;

        // PlayerPrefsにも保存
        PlayerPrefs.SetFloat("X_Sensitivity", defaultXSensitivity);
        PlayerPrefs.SetFloat("Y_Sensitivity", defaultYSensitivity);
        PlayerPrefs.Save();
    }

    private void SetX(float value)
    {
        Debug.Log($"X感度変更: {value}");
        seeScript.Xsensityvity = value;
        PlayerPrefs.SetFloat("X_Sensitivity", value);
    }

    private void SetY(float value)
    {
        Debug.Log($"Y感度変更: {value}");
        seeScript.Ysensityvity = value;
        PlayerPrefs.SetFloat("Y_Sensitivity", value);
    }
}
