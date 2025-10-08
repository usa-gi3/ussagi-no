using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    //[SerializeField] private string volumeKey = "BGMVolume"; // �V�[�����ƂɃ��j�[�N�ȃL�[��ݒ�
    [SerializeField] private AudioSource bgmSource;
    private static BGMManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // ��d�����h�~
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        // �ۑ����ꂽ���ʂ����[�h���Ĕ��f
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        bgmSource.volume = savedVolume;
        if (!bgmSource.isPlaying)   // �܂�����Ă��Ȃ���΍Đ�
        {
            bgmSource.Play();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);

        // �V�[������BGM�p��AudioSource������Ȃ獷���ւ�
        AudioSource sceneSource = GameObject.FindWithTag("BGMSource")?.GetComponent<AudioSource>();
        if (sceneSource != null)
        {
            bgmSource = sceneSource;
        }

        // ���ʂ��Ĕ��f
        bgmSource.volume = savedVolume;

        // �V�[�����ɉ�����BGM�؂�ւ�
        AudioClip newClip = Resources.Load<AudioClip>($"BGM/{scene.name}");
        if (newClip != null /*&& bgmSource != null */&& bgmSource.clip != newClip)
        {
            bgmSource.clip = newClip;
            //bgmSource.volume = PlayerPrefs.GetFloat("BGMVolume", 1f); // �ۑ��l�𔽉f
            bgmSource.Play();
        }
    }

    // Setting.cs ����Ă΂��
    public void RegisterSettingUI(GameObject settingUIInstance)
    {
        // �X���C�_�[��T��
        Slider slider = settingUIInstance.GetComponentInChildren<Slider>(true);

        if (slider != null)
        {
            slider.value = bgmSource.volume;
            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            //Debug.LogError("BGMVolumeSlider ��������܂���ł���");
        }
    }

    public void SetVolume(float value)
    {
        //Debug.Log("SetVolume: " + value);
        bgmSource.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }
}

