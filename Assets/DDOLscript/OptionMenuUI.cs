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

        // �����ʒu����ԏ�
        if (scrollRect != null)
            scrollRect.verticalNormalizedPosition = 1f;

        // �{�^���I��
        if (actionButton != null)
            EventSystem.current.SetSelectedGameObject(actionButton.gameObject);
    }

    void Update()
    {
        if (scrollRect != null)
        {
            // ���L�[�F������ɃX�N���[��
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition + scrollSpeed);
            // ���L�[�F�������ɃX�N���[��
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition - scrollSpeed);
        }

        // Enter / Space �Ń{�^�����s
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (actionButton != null)
                actionButton.onClick.Invoke();
        }
    }
}
