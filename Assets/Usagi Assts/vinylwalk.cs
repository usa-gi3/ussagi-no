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
        // A = 実測ベクトル方向
        if (Input.GetKey(KeyCode.A))
        {
            move += dirA;
        }
        // D = Aと逆方向にするなら
        if (Input.GetKey(KeyCode.D))
        {
            move -= dirA;
        }

        if (move.magnitude > 1f) move = move.normalized;

        //アニメーション
        animator.SetFloat("iswalking", move.magnitude);

        //移動
        controller.Move(move * speed * Time.deltaTime);

        // 向きを変える処理
        if (move != Vector3.zero)
        {
            // 移動方向へ回転
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
