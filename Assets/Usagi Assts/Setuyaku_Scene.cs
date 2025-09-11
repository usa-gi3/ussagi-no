using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setuyaku_Scene : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject One_Camera; // �J����1
    public GameObject Two_Camera; // �J����2

    // �ړ���̍��W�iBar1��Bar2�j
    Vector3 Bar1Position = new Vector3(1.466238f, -5.756f, 3.129455f);
    Vector3 Bar2Position = new Vector3(-7f, 5f, 3f);

    private string currentTrigger = ""; // ���ݐڐG���Ă���I�u�W�F�N�g�̃^�O

    // �Q�[���J�n���ɃJ����1��L����
=======
    public GameObject One_Camera;
    public GameObject Two_Camera;
    public GameObject player; // �v���C���[���w��

    Vector3 Bar1Position = new Vector3(-5.845f, -5.756f, 3.512f);
    Vector3 Bar2Position = new Vector3(0.252f, 0.152f, 0.672f);

    private Collider triggeredObject;

>>>>>>> mochi
    void Start()
    {
        One_Camera.SetActive(true);
        Two_Camera.SetActive(false);
    }

    // �g���K�[�ɓ������Ƃ��Ƀ^�O���L�^
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bar1") || other.CompareTag("Bar2"))
        {
<<<<<<< HEAD
            currentTrigger = other.tag;
        }
    }

    // �g���K�[����o���Ƃ��Ƀ^�O�����Z�b�g
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bar1") || other.CompareTag("Bar2"))
        {
            currentTrigger = "";
        }
    }

    // �X�y�[�X�L�[�������ꂽ��A�^�O�ɉ����ď��������s
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentTrigger == "Bar1")
            {
                One_Camera.SetActive(true);
                Two_Camera.SetActive(false);
                transform.position = Bar1Position;
            }
            else if (currentTrigger == "Bar2")
            {
                One_Camera.SetActive(false);
                Two_Camera.SetActive(true);
                transform.position = Bar2Position;
            }
        }
    }
=======
            triggeredObject = other;
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

            triggeredObject = null;
        }
    }
>>>>>>> mochi
}