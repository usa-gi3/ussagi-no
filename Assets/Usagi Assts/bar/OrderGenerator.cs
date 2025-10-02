
using UnityEngine;
using System.Collections.Generic;

public class OrderGenerator : MonoBehaviour
{
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


    public List<int> currentOrder = new List<int>(); // 4桁の注文番号

    private List<GameObject> upDrinks;
    private List<GameObject> middleDrinks;
    private List<GameObject> downDrinks;


    public ObjectClickManager clickManager;

    void Start()
    {
      
        upDrinks = new List<GameObject> { UP_Drink1, UP_Drink2, UP_Drink3, UP_Drink4, UP_Drink5 };
        middleDrinks = new List<GameObject> { In_Drink1, In_Drink2, In_Drink3, In_Drink4, In_Drink5 };
        downDrinks = new List<GameObject> { Down_Drink1, Down_Drink2, Down_Drink3, Down_Drink4, Down_Drink5 };
        Reset();

        GenerateOrder();
        DrinkOut();
    }

    void DrinkOut()
    {
       

        if (currentOrder.Count >= 1)
        {
            int bottom = currentOrder[0];
            if (bottom >= 0 && bottom <= 4)
                ShowOnlyInGroup(downDrinks[bottom], downDrinks);
        }

        if (currentOrder.Count >= 2)
        {
            int middle = currentOrder[1];
            if (middle >= 0 && middle <= 4)
                ShowOnlyInGroup(middleDrinks[middle], middleDrinks);
        }

        if (currentOrder.Count >= 3)
        {
            int top = currentOrder[2];
            if (top >= 0 && top <= 4)
                ShowOnlyInGroup(upDrinks[top], upDrinks);
        }

        if (currentOrder.Count >= 4)
        {
            // ドリンクがすべて有効な番号（0〜4）であることを確認
            bool allDrinksValid =
                currentOrder[0] >= 0 && currentOrder[0] <= 4 &&
                currentOrder[1] >= 0 && currentOrder[1] <= 4 &&
                currentOrder[2] >= 0 && currentOrder[2] <= 4;

            if (allDrinksValid)
            {
                int fruit = currentOrder[3];
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

    public void GenerateOrder()
    {
        Reset();
        currentOrder.Clear();


        // 2〜4桁目：1〜5のドリンク番号
        for (int i = 0; i < 3; i++)
        {
            int drink = Random.Range(0, 5); // 1〜5
            currentOrder.Add(drink);
        }




        // 1桁目：1（Apple）または 2（Carrot）
        int fruit = Random.Range(5, 7); // 1〜2
        currentOrder.Add(fruit);





        Debug.Log("生成された注文: " + string.Join(", ", currentOrder));
    }

    public List<int> GetOrder()
    {
        return new List<int>(currentOrder);
    }

    void Reset()
    {
        foreach (var obj in upDrinks) obj.SetActive(false);
        foreach (var obj in middleDrinks) obj.SetActive(false);
        foreach (var obj in downDrinks) obj.SetActive(false);
        Apple.SetActive(false);
        Carrot.SetActive(false);
    }


    public void GenerateNewOrder()
    {
        currentOrder.Clear();
        clickManager.clickHistory.Clear();
        GenerateOrder();
        DrinkOut();
        Debug.Log("生成された注文: " + string.Join(", ", currentOrder));
    }



}
