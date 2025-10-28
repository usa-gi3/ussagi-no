using UnityEngine;
using System.Collections.Generic;

public class OrderChecker : MonoBehaviour
{
    public OrderGenerator orderGenerator;
    public ObjectClickManager clickManager;
    public int Clear;
    public ScoreManager scoreManager;
    

    void Update()
    {
        // Cheakerが1になったら判定を実行
        if (clickManager.Cheaker == 1)
        {
            CheckOrder();

            // 一度だけ実行したい場合はCheakerをリセット
            clickManager.Cheaker = 0;
        }
    }

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
            Clear++;
            scoreManager.UpdateScore(Clear);

            clickManager.Reset();
            orderGenerator.GenerateNewOrder();
        }
        else
        {
            Debug.Log("注文と違います！");
        }
    }
}