using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField]
    //�@�ݒ���UI�̃v���n�u
    private GameObject settingUIPrefab;
    //�@�ݒ���UI�̃C���X�^���X
    private GameObject settingUIInstance;

    public void setting_botton()
    {
        if (settingUIInstance == null)
        {
            // �C���X�^���X�����݂��Ȃ���ΐ������ĕ\��
            settingUIInstance = Instantiate(settingUIPrefab);

            // �{�^����T����OnClick�o�^
            Button backButton = settingUIInstance.transform.Find("Setting/Button").GetComponent<Button>();
            backButton.onClick.AddListener(OnBackButton);
        }
        else
        {
            // �C���X�^���X�����݂���΍폜�i��\���j
            Destroy(settingUIInstance);
        }
    }

    public void OnBackButton()
    {
        // �߂�{�^���Ŕ�\���i�폜�j
        if (settingUIInstance != null)
        {
            Destroy(settingUIInstance);
        }
    }
}