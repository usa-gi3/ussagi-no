using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    //[SerializeField] private string volumeKey = "BGMVolume"; // シーンごとにユニークなキーを設定
    [SerializeField] private AudioSource bgmSource;
    private static BGMManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // 二重生成防止
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        // 保存された音量をロードして反映
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        bgmSource.volume = savedVolume;
        if (!bgmSource.isPlaying)   // まだ流れていなければ再生
        {
            bgmSource.Play();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);

        // シーン内にBGM用のAudioSourceがあるなら差し替え
        AudioSource sceneSource = GameObject.FindWithTag("BGMSource")?.GetComponent<AudioSource>();
        if (sceneSource != null)
        {
            bgmSource = sceneSource;
        }

        // 音量を再反映
        bgmSource.volume = savedVolume;

        // シーン名に応じてBGM切り替え
        AudioClip newClip = Resources.Load<AudioClip>($"BGM/{scene.name}");
        if (newClip != null /*&& bgmSource != null */&& bgmSource.clip != newClip)
        {
            bgmSource.clip = newClip;
            //bgmSource.volume = PlayerPrefs.GetFloat("BGMVolume", 1f); // 保存値を反映
            bgmSource.Play();
        }
    }

    // Setting.cs から呼ばれる
    public void RegisterSettingUI(GameObject settingUIInstance)
    {
        // スライダーを探す
        Slider slider = settingUIInstance.GetComponentInChildren<Slider>(true);

        if (slider != null)
        {
            slider.value = bgmSource.volume;
            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            //Debug.LogError("BGMVolumeSlider が見つかりませんでした");
        }
    }

    public void SetVolume(float value)
    {
        //Debug.Log("SetVolume: " + value);
        bgmSource.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }
}

