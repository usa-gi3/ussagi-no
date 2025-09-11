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
        // 入力取得
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        input = input.normalized;

        // カメラの向きに合わせて移動方向を補正
        Transform cam = Camera.main.transform;
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        // 水平移動に限定（Y軸を無視）
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // カメラ基準の移動方向
        Vector3 moveInput = camForward * input.z + camRight * input.x;
        moveInput = moveInput.normalized;

        // 地面にいるときの移動処理
        if (controller.isGrounded)
        {
            moveDirection = moveInput * speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // プレイヤーの向きを移動方向に回転
        if (moveInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // アニメーション制御
        animator.SetFloat("iswalking", input.magnitude);

        // 重力処理
        moveDirection.y -= gravity * Time.deltaTime;

        // 実際に移動
        controller.Move(moveDirection * Time.deltaTime);
    }
}