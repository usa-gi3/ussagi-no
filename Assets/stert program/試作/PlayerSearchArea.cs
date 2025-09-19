using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerSearchArea : MonoBehaviour
{
    public float areaRadius = 5f;

    // 前フレームで見えていたオブジェクトを保持
    private HashSet<InvisibleObject> previousVisibleObjects = new HashSet<InvisibleObject>();

    void Update()
    {
        // 今回フレームで範囲内にいるオブジェクトを一時保存
        HashSet<InvisibleObject> currentVisibleObjects = new HashSet<InvisibleObject>();

        Collider[] hits = Physics.OverlapSphere(transform.position, areaRadius);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<InvisibleObject>(out var obj))
            {
                float distance = (transform.position - hit.transform.position).magnitude;
                float alpha = Mathf.Clamp(1 - distance / areaRadius, 0.2f, 1f);
                obj.SetVisibility(true, alpha);

                // 今回の範囲内にいるのでセット
                currentVisibleObjects.Add(obj);
            }
        }

        // 前フレームにいて今回の範囲外になったオブジェクトは透明に戻す
        foreach (var obj in previousVisibleObjects)
        {
            if (!currentVisibleObjects.Contains(obj))
            {
                obj.SetVisibility(false);
            }
        }

        // 今回の状態を保存して次フレームに引き継ぐ
        previousVisibleObjects = currentVisibleObjects;
    }
}
