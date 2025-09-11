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
        // 入力取得（ワールド座標系）
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        input = input.normalized;

        // 地面にいるときの移動処理
        if (controller.isGrounded)
        {
            moveDirection = input * speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // プレイヤーの向きを移動方向に回転させる（カメラ固定なのでワールド座標でOK）
        if (input != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(input);
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