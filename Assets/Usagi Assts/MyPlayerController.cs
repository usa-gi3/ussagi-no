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
            controller.enabled = false; // ← 一時的に無効化
            transform.position = PositionMemory.returnPosition; // ← 位置を復元
            controller.enabled = true; // ← 再び有効化
        }
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        // 水平移動部分を常に更新
        Vector3 horizontalMove = transform.TransformDirection(input) * speed;

        if (controller.isGrounded)
        {
            moveDirection = horizontalMove;   // ← 水平は常に更新
            moveDirection.y = -1f;            // 地面に押し付ける

            if (Input.GetKeyDown(KeyCode.Space)) // ジャンプ
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection.x = horizontalMove.x; // ← 空中でも水平入力反映
            moveDirection.z = horizontalMove.z;
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // アニメーション用
        animator.SetFloat("iswalking", input.magnitude);

        // 移動実行
        controller.Move(moveDirection * Time.deltaTime);
    }
}