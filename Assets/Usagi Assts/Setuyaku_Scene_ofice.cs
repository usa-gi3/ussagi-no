using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setuyaku_Scene_ofice : MonoBehaviour
{
    public GameObject One_Camera; // �J����1
    public GameObject Two_Camera; // �J����2
    public GameObject player;     // �v���C���[�I�u�W�F�N�g

    // Bar1��Bar2�̈ړ�����W
    Vector3 ofice1Position = new Vector3(10.88f,2.78f,11.6f);
    Vector3 ofice2Position = new Vector3(3.05f, -2.62f, 4.8f);

    private Collider triggeredObject = null; // ���ݐڐG���Ă���g���K�[

    void Start()
    {
        One_Camera.SetActive(true);
        Two_Camera.SetActive(false);
    }

    // �g���K�[�ɓ������Ƃ��ɋL�^
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ofice1") || other.CompareTag("ofice2"))
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
            if (triggeredObject.CompareTag("ofice1"))
            {
                One_Camera.SetActive(true);
                Two_Camera.SetActive(false);
                player.transform.position = ofice1Position;
            }
            else if (triggeredObject.CompareTag("ofice2"))
            {
                One_Camera.SetActive(false);
                Two_Camera.SetActive(true);
                player.transform.position = ofice2Position;
            }

            triggeredObject = null; // ������Ƀ��Z�b�g
        }
    }
}