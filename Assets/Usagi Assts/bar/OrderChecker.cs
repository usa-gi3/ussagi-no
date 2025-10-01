
using UnityEngine;
using System.Collections.Generic;

public class OrderChecker : MonoBehaviour
{
    public OrderGenerator orderGenerator;
    public ObjectClickManager clickManager;

    public void CheckOrder()
    {
        List<int> order = orderGenerator.GetOrder(); // 1桁目: フルーツ, 2〜4桁目: ドリンク
        List<int> player = clickManager.GetFullHistory(); // プレイヤーの履歴（4件）

        if (player.Count < 4)
        {
            Debug.Log("まだ入力が足りません");
            return;
        }

        bool isMatch = true;
        for (int i = 0; i < 4; i++)
        {
            if (order[i] != player[i])
            {
                isMatch = false;
                break;
            }
        }

        if (isMatch)
        {
            Debug.Log("注文通り！正解です！");
        }
        else
        {
            Debug.Log("注文と違います！");
        }
    }
}
