using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public ScrollRect scrollRect; // ScrollRect��Inspector�Ŏw��
    public float scrollSpeed = 0.5f; // �X�N���[�����x

    void Update()
    {
        if (scrollRect != null)
        {
            // �ォ�牺�֎����X�N���[���i0����ԉ��A1����ԏ�j
            scrollRect.verticalNormalizedPosition -= scrollSpeed * Time.deltaTime;

            // �ŉ����܂œ��B�������ɖ߂�
            if (scrollRect.verticalNormalizedPosition <= 0f)
            //{
                scrollRect.verticalNormalizedPosition = 1f;
            //}
        }
    }
}
