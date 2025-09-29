using UnityEngine;
using System.Collections.Generic;

public class Bar_GameManager : MonoBehaviour
{
    public static Bar_GameManager Instance;

    [Header("ドリンクアイテム上（5種類の中から1つ）")]
    public GameObject[] drinkItems_ON;

    [Header("ドリンクアイテム中（5種類の中から1つ）")]
    public GameObject[] drinkItems_IN;

    [Header("ドリンクアイテム下（5種類の中から1つ）")]
    public GameObject[] drinkItems_DOWN;

    [Header("飾りアイテム（2種類の中から1つ）")]
    public GameObject[] decorItems;

    public List<int> selectedDrinks = new List<int>();
    public int maxDrinks = 3;

    public int selectedDecor = -1; // -1 = 未選択
    public int maxDecor = 1;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        RegisterItems(drinkItems_ON, true);   // ドリンクID: 1〜5（上）
        RegisterItems(drinkItems_IN, true);   // ドリンクID: 6〜10（中）
        RegisterItems(drinkItems_DOWN, true); // ドリンクID: 11〜15（下）
        RegisterItems(decorItems, false);     // 飾りID: 101〜102
    }

    void RegisterItems(GameObject[] items, bool isDrink)
    {
        for (int i = 0; i < items.Length; i++)
        {
            int id;
            if (isDrink)
            {
                id = selectedDrinks.Count + i + 1; // ドリンクIDをユニークに
            }
            else
            {
                id = 101 + i; // 飾りID
            }

            ItemClickBinder.Bind(items[i], id, isDrink);
        }
    }

    public void OnItemClicked(int itemID, bool isDrink)
    {
        if (isDrink)
        {
            if (selectedDrinks.Contains(itemID))
            {
                Debug.Log("⚠️ すでに選択済みのドリンクです");
                return;
            }

            if (selectedDrinks.Count >= maxDrinks)
            {
                Debug.Log("⚠️ ドリンクは最大3個までです");
                return;
            }

            selectedDrinks.Add(itemID);
            Debug.Log($"ドリンク選択: {itemID}（合計: {selectedDrinks.Count}）");
        }
        else
        {
            if (selectedDecor != -1)
            {
                Debug.Log("⚠️ 飾りは1つだけ選べます");
                return;
            }

            selectedDecor = itemID;
            Debug.Log($"飾り選択: {itemID}");
        }
    }

    public void ResetSelections()
    {
        selectedDrinks.Clear();
        selectedDecor = -1;
        Debug.Log("選択状態をリセットしました");
    }
}