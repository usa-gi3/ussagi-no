using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityManager : MonoBehaviour
{
    [SerializeField] private See seeScript; // ���x�������Ă���X�N���v�g���Q��
    [SerializeField] private float defaultXSensitivity = 0.5f; // �� �f�t�H���g�l��ݒ�
    [SerializeField] private float defaultYSensitivity = 0.5f; // �� �f�t�H���g�l��ݒ�
    private Slider xSlider;
    private Slider ySlider;

    // Setting.cs ����Ă΂��
    public void RegisterSettingUI(GameObject settingUIInstance)
    {
        Debug.Log("RegisterSettingUI ���Ă΂�܂���");

        // SettingUI ���̃X���C�_�[��S���T��
        Slider[] sliders = settingUIInstance.GetComponentsInChildren<Slider>(true);
        Debug.Log($"���������X���C�_�[��: {sliders.Length}");

        foreach (var slider in sliders)
        {
            Debug.Log($"�X���C�_�[��: {slider.name}");

            if (slider.name == "xSlider")
            {
                xSlider = slider;
                xSlider.value = PlayerPrefs.GetFloat("X_Sensitivity", seeScript.Xsensityvity);
                xSlider.onValueChanged.RemoveAllListeners();
                xSlider.onValueChanged.AddListener(SetX);
                Debug.Log($"X�X���C�_�[�ݒ芮��: {xSlider.value}");
            }
            else if (slider.name == "ySlider")
            {
                ySlider = slider;
                ySlider.value = PlayerPrefs.GetFloat("Y_Sensitivity", seeScript.Ysensityvity);
                ySlider.onValueChanged.RemoveAllListeners();
                ySlider.onValueChanged.AddListener(SetY);
                Debug.Log($"Y�X���C�_�[�ݒ芮��: {ySlider.value}");
            }
        }

        // �� ���Z�b�g�{�^�����T���Đݒ�
        Button[] buttons = settingUIInstance.GetComponentsInChildren<Button>(true);
        foreach (var button in buttons)
        {
            if (button.name == "ResetButton") // ���Z�b�g�{�^���̖��O
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(ResetToDefault);
                Debug.Log("���Z�b�g�{�^���ݒ芮��");
            }
        }
    }

    // �� �f�t�H���g�l�Ƀ��Z�b�g����֐�
    public void ResetToDefault()
    {
        Debug.Log("���x���f�t�H���g�l�Ƀ��Z�b�g");

        // �X���C�_�[�̒l���X�V�i����ɂ��SetX�ASetY���Ă΂��j
        if (xSlider != null)
        {
            xSlider.value = defaultXSensitivity;
        }
        if (ySlider != null)
        {
            ySlider.value = defaultYSensitivity;
        }

        // ���ڒl���X�V�i�O�̂��߁j
        seeScript.Xsensityvity = defaultXSensitivity;
        seeScript.Ysensityvity = defaultYSensitivity;

        // PlayerPrefs�ɂ��ۑ�
        PlayerPrefs.SetFloat("X_Sensitivity", defaultXSensitivity);
        PlayerPrefs.SetFloat("Y_Sensitivity", defaultYSensitivity);
        PlayerPrefs.Save();
    }

    private void SetX(float value)
    {
        Debug.Log($"X���x�ύX: {value}");
        seeScript.Xsensityvity = value;
        PlayerPrefs.SetFloat("X_Sensitivity", value);
    }

    private void SetY(float value)
    {
        Debug.Log($"Y���x�ύX: {value}");
        seeScript.Ysensityvity = value;
        PlayerPrefs.SetFloat("Y_Sensitivity", value);
    }
}
