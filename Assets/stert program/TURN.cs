using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TURN : MonoBehaviour
{
    [Tooltip("��]���x�i�x/�b�j")]
    public float rotationSpeed = 30f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
