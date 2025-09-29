using UnityEngine;

public class ItemClickBinder : MonoBehaviour
{
    public static void Bind(GameObject obj, int id, bool isDrink)
    {
        var proxy = obj.AddComponent<ItemClickProxy>();
        proxy.itemID = id;
        proxy.isDrink = isDrink;
    }
}