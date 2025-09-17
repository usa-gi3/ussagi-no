using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TURN : MonoBehaviour
{
    [Tooltip("回転速度（度/秒）")]
    public float rotationSpeed = 30f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
