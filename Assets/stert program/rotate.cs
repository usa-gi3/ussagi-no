using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [Header("観覧車全体")]
    public Transform wheel;           // 観覧車の本体

    [Header("ゴンドラたち")]
    public Transform[] gondolas;      // ゴンドラの配列

    [Header("回転速度設定")]
    public float wheelSpeed = 10f;    // 観覧車の回転速度
    public float gondolaSpeed = -10f; // ゴンドラの回転速度（逆方向）
    public float gondolaSpinSpeed = 10f;  // ゴンドラ自身の回転速度（必要なら）

    void Start()
    {
        // ゴンドラを wheel の子にして「ぶら下げる」
        foreach (Transform gondola in gondolas)
        {
            gondola.SetParent(wheel, true); // true: ワールド座標を保持して親子化
        }
    }

    void Update()
    {
        // 観覧車本体をZ軸基準で回転
        wheel.Rotate(Vector3.forward * wheelSpeed * Time.deltaTime);

        // ゴンドラを常にワールドの下方向へ向ける
        foreach (Transform gondola in gondolas)
        {
            gondola.up = Vector3.up * 1;  // 上ベクトルを真下に固定（=地面に対して下向き）
        }
    }
    
}