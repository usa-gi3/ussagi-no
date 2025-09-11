using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vinylwalk : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController controller;
    private Animator animator;

    private Vector3 dirA;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        dirA = new Vector3(-0.238f, 0f, -0.122f).normalized;
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        // W = +Z
        if (Input.GetKey(KeyCode.W))
        {
            move += Vector3.forward;
        }
        // S = -Z
        if (Input.GetKey(KeyCode.S))
        {
            move += Vector3.back;
        }
        // A = ŽÀ‘ªƒxƒNƒgƒ‹•ûŒü
        if (Input.GetKey(KeyCode.A))
        {
            move += dirA;
        }
        // D = A‚Æ‹t•ûŒü‚É‚·‚é‚È‚ç
        if (Input.GetKey(KeyCode.D))
        {
            move -= dirA;
        }

        if (move.magnitude > 1f) move = move.normalized;

        animator.SetFloat("iswalking", move.magnitude);

        controller.Move(move * speed * Time.deltaTime);
    }
}
