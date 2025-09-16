using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
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

        if (PositionMemory.hasSavedPosition)
        {
            controller.enabled = false; // �� �ꎞ�I�ɖ�����
            transform.position = PositionMemory.returnPosition; // �� �ʒu�𕜌�
            controller.enabled = true; // �� �ĂїL����
        }
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        // �����ړ���������ɍX�V
        Vector3 horizontalMove = transform.TransformDirection(input) * speed;

        if (input.magnitude > 0.1f)
        {
            // ���[�J�������[���h���W�ɕϊ�
            Vector3 worldDirection = transform.TransformDirection(input);
            worldDirection.y = 0f; // ��]�ɍ����͕s�v

            // �����̍X�V�i���炩�ɉ�]�j
            Quaternion targetRotation = Quaternion.LookRotation(worldDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }


        if (controller.isGrounded)
        {
            moveDirection = horizontalMove;   // �� �����͏�ɍX�V
            moveDirection.y = -1f;            // �n�ʂɉ����t����

            if (Input.GetKeyDown(KeyCode.LeftShift)) // �W�����v
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection.x = horizontalMove.x; // �� �󒆂ł��������͔��f
            moveDirection.z = horizontalMove.z;
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // �A�j���[�V�����p
        animator.SetFloat("iswalking", input.magnitude);

        // �ړ����s
        controller.Move(moveDirection * Time.deltaTime);
    }
}