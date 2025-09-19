using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class InvisibleObject : MonoBehaviour
{
    // ����Ώ�
    private MeshRenderer mesh;

    // �������ǂ���
    public bool IsVisible { get; private set; } = false;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        SetVisibility(false); // ������Ԃ͓���
    }


    // ������ݒ肵�C������ꍇ��alpha�l���w��\
    public void SetVisibility(bool visibility, float alpha = 1f)
    {
        IsVisible = visibility;
        SetMeshAlpha(IsVisible ? alpha : 0f);
    }

    // ���ۂɃ}�e���A���̃A���t�@�l��ς���
    private void SetMeshAlpha(float alpha)
    {
        if (mesh == null) return;

        foreach (var mat in mesh.materials)
        {
            Color c = mat.color;
            c.a = alpha;   // �����x��ݒ�
            mat.color = c;
        }
    }
}
