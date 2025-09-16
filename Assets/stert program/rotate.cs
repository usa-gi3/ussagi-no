using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [Header("�ϗ��ԑS��")]
    public Transform wheel;           // �ϗ��Ԃ̖{��

    [Header("�S���h������")]
    public Transform[] gondolas;      // �S���h���̔z��

    [Header("��]���x�ݒ�")]
    public float wheelSpeed = 10f;    // �ϗ��Ԃ̉�]���x
    public float gondolaSpeed = -10f; // �S���h���̉�]���x�i�t�����j
    public float gondolaSpinSpeed = 10f;  // �S���h�����g�̉�]���x�i�K�v�Ȃ�j

    void Start()
    {
        // �S���h���� wheel �̎q�ɂ��āu�Ԃ牺����v
        foreach (Transform gondola in gondolas)
        {
            gondola.SetParent(wheel, true); // true: ���[���h���W��ێ����Đe�q��
        }
    }

    void Update()
    {
        // �ϗ��Ԗ{�̂�Z����ŉ�]
        wheel.Rotate(Vector3.forward * wheelSpeed * Time.deltaTime);

        // �S���h������Ƀ��[���h�̉������֌�����
        foreach (Transform gondola in gondolas)
        {
            gondola.up = Vector3.up * 1;  // ��x�N�g����^���ɌŒ�i=�n�ʂɑ΂��ĉ������j
        }
    }
    
}