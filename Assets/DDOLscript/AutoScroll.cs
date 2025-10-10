using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public RectTransform content; // Contentを指定
    public float speed = 50f; // スクロール速度
    public float startY = -914.1f;  // 開始位置
    public float endY = 0f;     // 終了位置
    
    private VerticalLayoutGroup layoutGroup;
    private ContentSizeFitter fitter;
    private ScrollRect scrollRect;

    void Start()
    {
        Debug.Log("AutoScroll Start, content=" + (content ? content.name : "NULL"));
        if (content == null) { Debug.LogError("content is null"); return; }
        content.anchoredPosition = new Vector2(0, -100f);
        Debug.Log("Start set anchoredY = " + content.anchoredPosition.y);

        // Layoutの干渉を防ぐ
        layoutGroup = content.GetComponent<VerticalLayoutGroup>();
        fitter = content.GetComponent<ContentSizeFitter>();
        if (layoutGroup) layoutGroup.enabled = false;
        if (fitter) fitter.enabled = false;

        scrollRect = GetComponent<ScrollRect>();
        if (scrollRect != null)
            scrollRect.enabled = false; // ScrollRectの干渉を防ぐ

        // 開始位置を設定
        content.anchoredPosition = new Vector2(0, startY);
    }

    void Update()
    {
        if (content == null) return;

        float newY = content.anchoredPosition.y + speed * Time.deltaTime;
        content.anchoredPosition = new Vector2(0, newY);

        // 終了位置に到達したら止める
        if (content.anchoredPosition.y >= endY)
        {
            content.anchoredPosition = new Vector2(0, endY);
            enabled = false;
        }
    }
}
