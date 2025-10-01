using UnityEngine;
using System.Collections.Generic;

public class ObjectClickManager : MonoBehaviour
{
    public List<GameObject> targetObjects; // Unityエディタで登録
   

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



    private List<int> clickHistory = new List<int>();

    private List<GameObject> upDrinks;
    private List<GameObject> middleDrinks;
    private List<GameObject> downDrinks;


    public List<int> GetFullHistory()
    {
        return new List<int>(clickHistory);
    }



    void Start()
    {
        upDrinks = new List<GameObject> { UP_Drink1, UP_Drink2, UP_Drink3, UP_Drink4, UP_Drink5 };
        middleDrinks = new List<GameObject> { In_Drink1, In_Drink2, In_Drink3, In_Drink4, In_Drink5 };
        downDrinks = new List<GameObject> { Down_Drink1, Down_Drink2, Down_Drink3, Down_Drink4, Down_Drink5 };

        Reset();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                int index = targetObjects.IndexOf(clickedObject);

                if (index != -1)
                {
                    if (index == 7)
                    {
                        clickHistory.Clear();
                        Reset();
                        Debug.Log("履歴をリセットしました");
                    }
                    else
                    {
                        // フルーツの番号（例：1, 2, 5, 6）を制限
                        bool isFruit = (index == 5 || index == 6);

                        if (isFruit && clickHistory.Count < 3)
                        {
                            Debug.Log("ドリンクが3つ揃っていないため、フルーツは追加できません");
                            return;
                        }

                        if (clickHistory.Count < 4)
                        {
                            clickHistory.Add(index); // 古い順に追加
                            Debug.Log("クリックされた番号: " + index);
                            DrinkOut();
                        }
                        else
                        {
                            Debug.Log("履歴が満杯（4件）なので追加しません");
                        }
                    }

                    Debug.Log("履歴（古い順）: " + string.Join(", ", clickHistory));
                }
            }


        }
    }

    void DrinkOut()
    {
        Reset(); // 表示を初期化

        if (clickHistory.Count >= 1)
        {
            int bottom = clickHistory[0];
            if (bottom >= 0 && bottom <= 4)
                ShowOnlyInGroup(downDrinks[bottom], downDrinks);
        }

        if (clickHistory.Count >= 2)
        {
            int middle = clickHistory[1];
            if (middle >= 0 && middle <= 4)
                ShowOnlyInGroup(middleDrinks[middle], middleDrinks);
        }

        if (clickHistory.Count >= 3)
        {
            int top = clickHistory[2];
            if (top >= 0 && top <= 4)
                ShowOnlyInGroup(upDrinks[top], upDrinks);
        }

        if (clickHistory.Count >= 4)
        {
            // ドリンクがすべて有効な番号（0〜4）であることを確認
            bool allDrinksValid =
                clickHistory[0] >= 0 && clickHistory[0] <= 4 &&
                clickHistory[1] >= 0 && clickHistory[1] <= 4 &&
                clickHistory[2] >= 0 && clickHistory[2] <= 4;

            if (allDrinksValid)
            {
                int fruit = clickHistory[3];
                if (fruit == 1 || fruit == 5) Apple.SetActive(true);
                else if (fruit == 2 || fruit == 6) Carrot.SetActive(true);
            }
            else
            {
                Debug.Log("ドリンクがすべて揃っていないため、フルーツは表示されません");
            }
        }

    }

    void ShowOnlyInGroup(GameObject selected, List<GameObject> group)
    {
        foreach (GameObject obj in group)
        {
            obj.SetActive(obj == selected);
        }
    }

    void Reset()
    {
        foreach (var obj in upDrinks) obj.SetActive(false);
        foreach (var obj in middleDrinks) obj.SetActive(false);
        foreach (var obj in downDrinks) obj.SetActive(false);
        Apple.SetActive(false);
        Carrot.SetActive(false);
    }
}


