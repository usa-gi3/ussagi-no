using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class See : MonoBehaviour
{
    public GameObject cam;
    public float Xsensityvity = 3f; // �㉺���x
    public float Ysensityvity = 3f; // ���E���x

    Quaternion cameraRot, characterRot;
    bool cursorLock = true;

    // �㉺��]�̐���
    float minX = -90f, maxX = 90f;

    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
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
}