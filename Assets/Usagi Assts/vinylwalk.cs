using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vinylwalk : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;

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
        // A = �����x�N�g������
        if (Input.GetKey(KeyCode.A))
        {
            move += dirA;
        }
        // D = A�Ƌt�����ɂ���Ȃ�
        if (Input.GetKey(KeyCode.D))
        {
            move -= dirA;
        }

        if (move.magnitude > 1f) move = move.normalized;

        //�A�j���[�V����
        animator.SetFloat("iswalking", move.magnitude);

        //�ړ�
        controller.Move(move * speed * Time.deltaTime);

        // ������ς��鏈��
        if (move != Vector3.zero)
        {
            // �ړ������։�]
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
