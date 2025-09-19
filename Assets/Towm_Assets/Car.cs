using UnityEngine;

public class Car : MonoBehaviour
{
    public float acceleration = 800f;
    public float steering = 100f;
    public float maxSpeed = 20f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0); // 安定性向上
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float steerInput = Input.GetAxis("Horizontal");

        // 前進・後退
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * moveInput * acceleration * Time.fixedDeltaTime);
        }

        // ステアリング（回転）
        Quaternion turnOffset = Quaternion.Euler(0, steerInput * steering * Time.fixedDeltaTime, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
