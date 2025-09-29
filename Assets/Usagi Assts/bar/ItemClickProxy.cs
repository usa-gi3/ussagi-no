using UnityEngine;

public class ItemClickProxy : MonoBehaviour
{
    public int itemID;
    public bool isDrink;

    void OnMouseDown()
    {
        Bar_GameManager.Instance.OnItemClicked(itemID, isDrink);
    }
}