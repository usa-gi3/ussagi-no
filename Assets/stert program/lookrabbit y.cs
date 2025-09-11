using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookrabbity : MonoBehaviour
{
    public Transform player;   // プレイヤーをインスペクターにセット
    public float heightOffset = 1.5f; // プレイヤーの少し上を見る

    void LateUpdate()
    {
        if (player == null) return;

        // プレイヤーの位置をターゲットにする
        Vector3 target = new Vector3(player.position.x,
                                     player.position.y + heightOffset,
                                     player.position.z);

        // カメラの位置は変えずに、プレイヤーの方向を向く
        transform.LookAt(target);
    }
}
