using UnityEngine;
using System.Collections.Generic;

public class ObjectClickManager : MonoBehaviour
{
    public List<GameObject> targetObjects; // Unity�G�f�B�^�œo�^
    private List<int> clickHistory = new List<int>(); // ���l�����i�ő�4���j

    public GameObject UP_Drink1;
    public GameObject UP_Drink2;
    public GameObject UP_Drink3;
    public GameObject UP_Drink4;
    public GameObject UP_Drink5;
    public GameObject In_Drink1;
    public GameObject In_Drink2;
    public GameObject In_Drink3;
    public GameObject In_Drink4;
    public GameObject In_Drink5;
    public GameObject Down_Drink1;
    public GameObject Down_Drink2;
    public GameObject Down_Drink3;
    public GameObject Down_Drink4;
    public GameObject Down_Drink5;
    public GameObject Apple;
    public GameObject Carrot;

    int firstNumber;
    int secondNumber;
    int thirdNumber;
    int fourNumber;

    void Start()
    {
        Reset();
    }

    void DrinkOut()
    {
        if (clickHistory.Count >= 4)
        {
            // �t�B�[���h�ϐ��ɑ���iint ���Ē�`���Ȃ��j
            firstNumber = clickHistory[0];
            secondNumber = clickHistory[1];
            thirdNumber = clickHistory[2];
            fourNumber = clickHistory[3];

            Debug.Log("��Ԗڂ̐���: " + firstNumber);
            Debug.Log("��Ԗڂ̐���: " + secondNumber);
            Debug.Log("�O�Ԗڂ̐���: " + thirdNumber);
            Debug.Log("�l�Ԗڂ̐���: " + fourNumber);
        }
        else
        {
            Debug.Log("������4�������ł�");
            return; // ����������Ȃ��ꍇ�͏����𒆒f
        }

        // �ȉ��͗�����4������Ƃ��������s�����\������
        if (firstNumber == 0) UP_Drink1.SetActive(true);
        if (firstNumber == 1) UP_Drink2.SetActive(true);
        if (firstNumber == 2) UP_Drink3.SetActive(true);
        if (firstNumber == 3) UP_Drink4.SetActive(true);
        if (firstNumber == 4) UP_Drink5.SetActive(true);

        if (secondNumber == 0) In_Drink1.SetActive(true);
        if (secondNumber == 1) In_Drink2.SetActive(true);
        if (secondNumber == 2) In_Drink3.SetActive(true);
        if (secondNumber == 3) In_Drink4.SetActive(true);
        if (secondNumber == 4) In_Drink5.SetActive(true);

        if (thirdNumber == 0 || thirdNumber == 5) Down_Drink1.SetActive(true);
        if (thirdNumber == 1) Down_Drink2.SetActive(true);
        if (thirdNumber == 2) Down_Drink3.SetActive(true);
        if (thirdNumber == 3) Down_Drink4.SetActive(true);
        if (thirdNumber == 4) Down_Drink5.SetActive(true);

        if (fourNumber == 1) Apple.SetActive(true);
        if (fourNumber == 2) Carrot.SetActive(true);
    }




    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                int index = targetObjects.IndexOf(clickedObject);

                if (index != -1)
                {
                    // �ԍ���8�Ȃ痚�������Z�b�g
                    if (index == 7)
                    {
                        clickHistory.Clear();
                        Reset();
                        Debug.Log("�ԍ���7�������̂ŗ��������Z�b�g���܂���");
                    }
                    else
                    {
                        // ������4�������̂Ƃ������擪�ɒǉ�
                        if (clickHistory.Count < 4)
                        {
                            clickHistory.Insert(0, index); // �擪�ɒǉ�
                            Debug.Log("�N���b�N���ꂽ�ԍ�: " + index);
                            DrinkOut();
                        }
                        else
                        {
                            Debug.Log("���������t�i4���j�Ȃ̂Œǉ����܂���");
                        }
                    }

                    Debug.Log("�����i�V�������j: " + string.Join(", ", clickHistory));
                }
            }
        }
    }

    void Reset()
    {
        UP_Drink1.SetActive(false);
        UP_Drink2.SetActive(false);
        UP_Drink3.SetActive(false);
        UP_Drink4.SetActive(false);
        UP_Drink5.SetActive(false);
        In_Drink1.SetActive(false);
        In_Drink2.SetActive(false);
        In_Drink3.SetActive(false);
        In_Drink4.SetActive(false);
        In_Drink5.SetActive(false);
        Down_Drink1.SetActive(false);
        Down_Drink2.SetActive(false);
        Down_Drink3.SetActive(false);
        Down_Drink4.SetActive(false);
        Down_Drink5.SetActive(false);
        Apple.SetActive(false);
        Carrot.SetActive(false);
    }


}
