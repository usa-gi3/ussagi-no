using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ���͎擾
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        input = input.normalized;

        // �J�����̌����ɍ��킹�Ĉړ�������␳
        Transform cam = Camera.main.transform;
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        // �����ړ��Ɍ���iY���𖳎��j
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // �J������̈ړ�����
        Vector3 moveInput = camForward * input.z + camRight * input.x;
        moveInput = moveInput.normalized;

        // �n�ʂɂ���Ƃ��̈ړ�����
        if (controller.isGrounded)
        {
            moveDirection = moveInput * speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // �v���C���[�̌������ړ������ɉ�]
        if (moveInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // �A�j���[�V��������
        animator.SetFloat("iswalking", input.magnitude);

        // �d�͏���
        moveDirection.y -= gravity * Time.deltaTime;

        // ���ۂɈړ�
        controller.Move(moveDirection * Time.deltaTime);
    }
}