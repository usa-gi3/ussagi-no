using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private string volumeKey = "BGMVolume"; // �V�[�����ƂɃ��j�[�N�ȃL�[��ݒ�
    [SerializeField] private AudioSource bgmSource;

    [SerializeField] private GameObject settingsUIPrefab; //�ݒ���UI�v���n�u
    private GameObject settingsUIInstance;

    private Slider volumeSlider;

    void Start()
    {
        // �ۑ����ꂽ���ʂ����[�h���Ĕ��f
        float savedVolume = PlayerPrefs.GetFloat(volumeKey, 1f);
        bgmSource.volume = savedVolume;
        if (!bgmSource.isPlaying)   // �܂�����Ă��Ȃ���΍Đ�
        {
            bgmSource.Play();
        }
    }

    // �ݒ�{�^������Ă�
    public void ToggleSettings()
    {
        if (settingsUIInstance == null)
        {
            // �ݒ��ʂ𐶐�
            settingsUIInstance = Instantiate(settingsUIPrefab);

            // �X���C�_�[��T��
            volumeSlider = settingsUIInstance.transform.Find("Canvas/Setting/BGMVolumeSlider").GetComponent<Slider>();

            // �ۑ��l�𔽉f
            float savedVolume = PlayerPrefs.GetFloat(volumeKey, 1f);
            volumeSlider.value = savedVolume;

            // �l���ς�����Ƃ��ɔ��f
            volumeSlider.onValueChanged.RemoveAllListeners();
            volumeSlider.onValueChanged.AddListener(SetVolume);


            // �߂�{�^����T���ăC�x���g�o�^
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

