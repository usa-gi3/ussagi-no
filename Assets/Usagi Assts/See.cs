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
    bool cursorLock = true;

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
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        // ���E�F�v���C���[�̑̂���
        characterRot *= Quaternion.Euler(0f, xRot, 0f);

        // �㉺�F�J������X���i�c�j����
        cameraRot *= Quaternion.Euler(-yRot, 0f, 0f);
        cameraRot = ClampRotation(cameraRot); // �����Ŋp�x����

        // ��]�𔽉f
        transform.localRotation = characterRot;
        cam.transform.localRotation = cameraRot;

        UpdateCursorLock();
    }

    void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        Cursor.lockState = cursorLock ? CursorLockMode.Locked : CursorLockMode.None;
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