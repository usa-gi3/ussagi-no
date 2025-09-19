using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerSearchArea : MonoBehaviour
{
    public float areaRadius = 5f;

    // �O�t���[���Ō����Ă����I�u�W�F�N�g��ێ�
    private HashSet<InvisibleObject> previousVisibleObjects = new HashSet<InvisibleObject>();

    void Update()
    {
        // ����t���[���Ŕ͈͓��ɂ���I�u�W�F�N�g���ꎞ�ۑ�
        HashSet<InvisibleObject> currentVisibleObjects = new HashSet<InvisibleObject>();

        Collider[] hits = Physics.OverlapSphere(transform.position, areaRadius);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<InvisibleObject>(out var obj))
            {
                float distance = (transform.position - hit.transform.position).magnitude;
                float alpha = Mathf.Clamp(1 - distance / areaRadius, 0.2f, 1f);
                obj.SetVisibility(true, alpha);

                // ����͈͓̔��ɂ���̂ŃZ�b�g
                currentVisibleObjects.Add(obj);
            }
        }

        // �O�t���[���ɂ��č���͈̔͊O�ɂȂ����I�u�W�F�N�g�͓����ɖ߂�
        foreach (var obj in previousVisibleObjects)
        {
            if (!currentVisibleObjects.Contains(obj))
            {
                obj.SetVisibility(false);
            }
        }

        // ����̏�Ԃ�ۑ����Ď��t���[���Ɉ����p��
        previousVisibleObjects = currentVisibleObjects;
    }
}
