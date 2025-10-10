using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public RectTransform content; // Content���w��
    public float speed = 50f; // �X�N���[�����x
    public float startY = -914.1f;  // �J�n�ʒu
    public float endY = 0f;     // �I���ʒu
    
    private VerticalLayoutGroup layoutGroup;
    private ContentSizeFitter fitter;
    private ScrollRect scrollRect;

    void Start()
    {
        Debug.Log("AutoScroll Start, content=" + (content ? content.name : "NULL"));
        if (content == null) { Debug.LogError("content is null"); return; }
        content.anchoredPosition = new Vector2(0, -100f);
        Debug.Log("Start set anchoredY = " + content.anchoredPosition.y);

        // Layout�̊���h��
        layoutGroup = content.GetComponent<VerticalLayoutGroup>();
        fitter = content.GetComponent<ContentSizeFitter>();
        if (layoutGroup) layoutGroup.enabled = false;
        if (fitter) fitter.enabled = false;

        scrollRect = GetComponent<ScrollRect>();
        if (scrollRect != null)
            scrollRect.enabled = false; // ScrollRect�̊���h��

        // �J�n�ʒu��ݒ�
        content.anchoredPosition = new Vector2(0, startY);
    }

    void Update()
    {
        if (content == null) return;

        float newY = content.anchoredPosition.y + speed * Time.deltaTime;
        content.anchoredPosition = new Vector2(0, newY);

        // �I���ʒu�ɓ��B������~�߂�
        if (content.anchoredPosition.y >= endY)
        {
            content.anchoredPosition = new Vector2(0, endY);
            enabled = false;
        }
    }
}
