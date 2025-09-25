using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private string volumeKey = "BGMVolume"; // シーンごとにユニークなキーを設定
    [SerializeField] private AudioSource bgmSource;

    [SerializeField] private GameObject settingsUIPrefab; //設定画面UIプレハブ
    private GameObject settingsUIInstance;

    private Slider volumeSlider;

    void Start()
    {
        // 保存された音量をロードして反映
        float savedVolume = PlayerPrefs.GetFloat(volumeKey, 1f);
        bgmSource.volume = savedVolume;
        if (!bgmSource.isPlaying)   // まだ流れていなければ再生
        {
            bgmSource.Play();
        }
    }

    // 設定ボタンから呼ぶ
    public void ToggleSettings()
    {
        if (settingsUIInstance == null)
        {
            // 設定画面を生成
            settingsUIInstance = Instantiate(settingsUIPrefab);

            // スライダーを探す
            volumeSlider = settingsUIInstance.transform.Find("Canvas/Setting/BGMVolumeSlider").GetComponent<Slider>();

            // 保存値を反映
            float savedVolume = PlayerPrefs.GetFloat(volumeKey, 1f);
            volumeSlider.value = savedVolume;

            // 値が変わったときに反映
            volumeSlider.onValueChanged.RemoveAllListeners();
            volumeSlider.onValueChanged.AddListener(SetVolume);


            // 戻るボタンを探してイベント登録
            Button backButton = settingsUIInstance.transform.Find("Canvas/Setting/Button").GetComponent<Button>();
            backButton.onClick.AddListener(CloseSettings);
        }
        else
        {
            CloseSettings();
        }
    }

    private void CloseSettings()
    {
        if (settingsUIInstance != null)
        {
            Destroy(settingsUIInstance);
            settingsUIInstance = null;
        }
    }

    public void SetVolume(float value)
    {
        Debug.Log("SetVolume: " + value);
        bgmSource.volume = value;
        PlayerPrefs.SetFloat(volumeKey, value);
    }
}

