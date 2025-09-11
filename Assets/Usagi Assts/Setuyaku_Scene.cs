using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setuyaku_Scene : MonoBehaviour
{
    public GameObject One_Camera; // �J����1
    public GameObject Two_Camera; // �J����2
    public GameObject player;     // �v���C���[�I�u�W�F�N�g

    // Bar1��Bar2�̈ړ�����W
    Vector3 Bar1Position = new Vector3(1.466238f, -5.756f, 3.129455f);
    Vector3 Bar2Position = new Vector3(-7f, 5f, 3f);

    private Collider triggeredObject = null; // ���ݐڐG���Ă���g���K�[

    void Start()
    {
        One_Camera.SetActive(true);
        Two_Camera.SetActive(false);
    }

    // �g���K�[�ɓ������Ƃ��ɋL�^
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bar1") || other.CompareTag("Bar2"))
        {
            triggeredObject = other;
        }
    }

    // �g���K�[����o���Ƃ��Ƀ��Z�b�g
    void OnTriggerExit(Collider other)
    {
        if (other == triggeredObject)
        {
            triggeredObject = null;
        }
    }

    void Update()
    {
        if (triggeredObject != null && Input.GetKeyDown(KeyCode.Space))
        {
            if (triggeredObject.CompareTag("Bar1"))
            {
                One_Camera.SetActive(true);
                Two_Camera.SetActive(false);
                player.transform.position = Bar1Position;
            }
            else if (triggeredObject.CompareTag("Bar2"))
            {
                One_Camera.SetActive(false);
                Two_Camera.SetActive(true);
                player.transform.position = Bar2Position;
            }

            triggeredObject = null; // ������Ƀ��Z�b�g
        }
    }
}