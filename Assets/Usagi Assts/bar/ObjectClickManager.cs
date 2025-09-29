using UnityEngine;
using System.Collections.Generic;

public class ObjectClickManager : MonoBehaviour
{
    public List<GameObject> targetObjects; // Unityエディタで登録
    private List<int> clickHistory = new List<int>(); // 数値履歴（最大4件）

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
            // フィールド変数に代入（int を再定義しない）
            firstNumber = clickHistory[0];
            secondNumber = clickHistory[1];
            thirdNumber = clickHistory[2];
            fourNumber = clickHistory[3];

            Debug.Log("一番目の数字: " + firstNumber);
            Debug.Log("二番目の数字: " + secondNumber);
            Debug.Log("三番目の数字: " + thirdNumber);
            Debug.Log("四番目の数字: " + fourNumber);
        }
        else
        {
            Debug.Log("履歴が4件未満です");
            return; // 履歴が足りない場合は処理を中断
        }

        // 以下は履歴が4件あるときだけ実行される表示処理
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
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                int index = targetObjects.IndexOf(clickedObject);

                if (index != -1)
                {
                    // 番号が8なら履歴をリセット
                    if (index == 7)
                    {
                        clickHistory.Clear();
                        Reset();
                        Debug.Log("番号が7だったので履歴をリセットしました");
                    }
                    else
                    {
                        // 履歴が4件未満のときだけ先頭に追加
                        if (clickHistory.Count < 4)
                        {
                            clickHistory.Insert(0, index); // 先頭に追加
                            Debug.Log("クリックされた番号: " + index);
                            DrinkOut();
                        }
                        else
                        {
                            Debug.Log("履歴が満杯（4件）なので追加しません");
                        }
                    }

                    Debug.Log("履歴（新しい順）: " + string.Join(", ", clickHistory));
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
