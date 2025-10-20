using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class See : MonoBehaviour
{
    public GameObject cam;
    public float Xsensityvity = 3f; // �㉺���x
    public float Ysensityvity = 3f; // ���E���x

    public GameObject settingUIInstance;

    Quaternion cameraRot, characterRot;

    float xRotation = 0f; // �J�����̏㉺�p
    float yRotation = 0f; // �v���C���[�̍��E�p

    // �㉺��]�̐���
    float minX = -90f, maxX = 90f;

    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;

        // �ۑ�����Ă������x��ǂݍ���
        Xsensityvity = PlayerPrefs.GetFloat("X_Sensitivity", Xsensityvity);
        Ysensityvity = PlayerPrefs.GetFloat("Y_Sensitivity", Ysensityvity);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Ysensityvity;
        float mouseY = Input.GetAxis("Mouse Y") * Xsensityvity;

        // �p�x���X�V
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minX, maxX);

        // ��]�𔽉f
        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }


    // �㉺�̉�]�𐧌�����֐�
    Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2.0f;
        angleX = Mathf.Clamp(angleX, minX, maxX);
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    // --- �X���C�_�[�p�R�[���o�b�N ---
    public void SetX(float value)
    {
        Xsensityvity = value;
        PlayerPrefs.SetFloat("X_Sensitivity", value);
    }

    public void SetY(float value)
    {
        Ysensityvity = value;
        PlayerPrefs.SetFloat("Y_Sensitivity", value);
    }

    void OnDisable()
    {
        PlayerPrefs.Save(); // �V�[���J�ڂ�ݒ��ʕ������ɕۑ�
    }
}