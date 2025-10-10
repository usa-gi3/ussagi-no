using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public ScrollRect scrollRect; // ScrollRectをInspectorで指定
    public float scrollSpeed = 0.5f; // スクロール速度

    void Update()
    {
        if (scrollRect != null)
        {
            // 上から下へ自動スクロール（0が一番下、1が一番上）
            scrollRect.verticalNormalizedPosition -= scrollSpeed * Time.deltaTime;

            // 最下部まで到達したら上に戻す
            if (scrollRect.verticalNormalizedPosition <= 0f)
            //{
                scrollRect.verticalNormalizedPosition = 1f;
            //}
        }
    }
}
