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

        if (input.magnitude > 0.1f)
        {
            // ローカル→ワールド座標に変換
            Vector3 worldDirection = transform.TransformDirection(input);
            worldDirection.y = 0f; // 回転に高さは不要

            // 向きの更新（滑らかに回転）
            Quaternion targetRotation = Quaternion.LookRotation(worldDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }





        if (controller.isGrounded)
        {
            moveDirection = transform.TransformDirection(input) * speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // アニメーションのSpeedに値を渡す
        animator.SetFloat("iswalking", input.magnitude); // inputの大きさで歩行判断

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}