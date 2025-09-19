using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class InvisibleObject : MonoBehaviour
{
    // 制御対象
    private MeshRenderer mesh;

    // 透明かどうか
    public bool IsVisible { get; private set; } = false;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        SetVisibility(false); // 初期状態は透明
    }


    // 可視性を設定し，見える場合はalpha値を指定可能
    public void SetVisibility(bool visibility, float alpha = 1f)
    {
        IsVisible = visibility;
        SetMeshAlpha(IsVisible ? alpha : 0f);
    }

    // 実際にマテリアルのアルファ値を変える
    private void SetMeshAlpha(float alpha)
    {
        if (mesh == null) return;

        foreach (var mat in mesh.materials)
        {
            Color c = mat.color;
            c.a = alpha;   // 透明度を設定
            mat.color = c;
        }
    }
}
