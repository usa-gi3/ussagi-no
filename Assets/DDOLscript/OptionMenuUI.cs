using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionMenuUI : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Button actionButton;
    [SerializeField] private float scrollSpeed = 0.1f;

    void Start()
    {
        if (scrollRect == null) scrollRect = GetComponentInChildren<ScrollRect>(true);
        if (actionButton == null) actionButton = GetComponentInChildren<Button>(true);

        // 初期位置を一番上
        if (scrollRect != null)
            scrollRect.verticalNormalizedPosition = 1f;

        // ボタン選択
        if (actionButton != null)
            EventSystem.current.SetSelectedGameObject(actionButton.gameObject);
    }

    void Update()
    {
        if (scrollRect != null)
        {
            // ↑キー：上方向にスクロール
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition + scrollSpeed);
            // ↓キー：下方向にスクロール
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition - scrollSpeed);
        }

        // Enter / Space でボタン実行
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (actionButton != null)
                actionButton.onClick.Invoke();
        }
    }
}
