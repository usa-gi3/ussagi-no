
using UnityEngine;
using System.Collections.Generic;

public class OrderGenerator : MonoBehaviour
{
    public List<int> currentOrder = new List<int>(); // 4桁の注文番号

    void Start()
    {
        GenerateOrder();
    }

    public void GenerateOrder()
    {
        currentOrder.Clear();

        // 1桁目：1（Apple）または 2（Carrot）
        int fruit = Random.Range(1, 3); // 1〜2
        currentOrder.Add(fruit);

        // 2〜4桁目：1〜5のドリンク番号
        for (int i = 0; i < 3; i++)
        {
            int drink = Random.Range(1, 6); // 1〜5
            currentOrder.Add(drink);
        }

        Debug.Log("生成された注文: " + string.Join(", ", currentOrder));
    }

    public List<int> GetOrder()
    {
        return new List<int>(currentOrder);
    }
}
