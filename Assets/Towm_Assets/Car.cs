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
        rb.centerOfMass = new Vector3(0, -0.5f, 0); // ���萫����
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float steerInput = Input.GetAxis("Horizontal");

        // �O�i�E���
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * moveInput * acceleration * Time.fixedDeltaTime);
        }

        // �X�e�A�����O�i��]�j
        Quaternion turnOffset = Quaternion.Euler(0, steerInput * steering * Time.fixedDeltaTime, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
