using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityManager : MonoBehaviour
{
    [SerializeField] private See seeScript; // ���x�������Ă���X�N���v�g���Q��
    private Slider xSlider;
    private Slider ySlider;

    // Setting.cs ����Ă΂��
    public void RegisterSettingUI(GameObject settingUIInstance)
    {
        // SettingUI ���̃X���C�_�[��S���T��
        Slider[] sliders = settingUIInstance.GetComponentsInChildren<Slider>(true);

        foreach (var slider in sliders)
        {
            if (slider.name == "xSlider")
            {
                xSlider = slider;
                xSlider.value = PlayerPrefs.GetFloat("X_Sensitivity", seeScript.Xsensityvity);
                xSlider.onValueChanged.RemoveAllListeners();
                xSlider.onValueChanged.AddListener(SetX);
            }
            else if (slider.name == "ySlider")
            {
                ySlider = slider;
                ySlider.value = PlayerPrefs.GetFloat("Y_Sensitivity", seeScript.Ysensityvity);
                ySlider.onValueChanged.RemoveAllListeners();
                ySlider.onValueChanged.AddListener(SetY);
            }
        }
    }

    private void SetX(float value)
    {
        seeScript.Xsensityvity = value;
        PlayerPrefs.SetFloat("X_Sensitivity", value);
    }

    private void SetY(float value)
    {
        seeScript.Ysensityvity = value;
        PlayerPrefs.SetFloat("Y_Sensitivity", value);
    }
}
