using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    //Audio�~�L�T�[������Ƃ�
    [SerializeField] AudioMixer audioMixer;

    //���ꂼ��̃X���C�_�[������Ƃ�
    [SerializeField] Slider BGMSlider;
    //[SerializeField] Slider SESlider;

    private void Start()
    {
        //�~�L�T�[��volume�ɃX���C�_�[��volume

        //BGM
        audioMixer.GetFloat("BGM", out float bgmVolume);
        BGMSlider.value = bgmVolume;
        //SE
        //audioMixer.GetFloat("SE", out float seVolume);
        //SESlider.value = seVolume;
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    /*public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }*/
}
