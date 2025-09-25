using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class talknpc : MonoBehaviour
{
    public GameObject dialogueUI; // Canvas内の会話UIをセット
    public TMP_Text dialogueText; // セリフ表示用Text (TextMeshProならTMP_Textに変更)
    public string[] messages; // NPCのセリフ一覧
    public GameObject player; //プレイヤー

    [SerializeField] private GameObject talkMark; // 会話可能マーク
    [SerializeField] private Camera mainCamera;   // メインカメラ

    private bool playerInRange = false;
    private int messageIndex = 0;
    private bool isTalking = false;

    void Start()
    {
        dialogueUI.SetActive(false); // ゲーム開始時に枠を消す
        if (talkMark != null) talkMark.SetActive(false);//マークを非表示に
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTalking)
            {
                StartDialogue();
            }
            else
            {
                NextMessage();
            }
        }
    }
    private void LateUpdate()
    {
        // マークをカメラの方向に向ける
        if (talkMark != null && talkMark.activeSelf)
        {
            talkMark.transform.LookAt(talkMark.transform.position + mainCamera.transform.forward);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (talkMark != null) talkMark.SetActive(true); // 範囲に入ったらマーク表示
            Debug.Log("判定入った");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (talkMark != null) talkMark.SetActive(false); // 範囲から出たら非表示
            EndDialogue();
        }
    }
    void StartDialogue()
    {
        isTalking = true;
        messageIndex = 0;
        dialogueUI.SetActive(true);
        dialogueText.text = messages[messageIndex];

        // 会話中はプレイヤーの動きを止める
        var pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = false;

        var myPc = player.GetComponent<MyPlayerController>();
        if (myPc != null) myPc.enabled = false;
    }

    void NextMessage()
    {
        messageIndex++;
        if (messageIndex < messages.Length)
        {
            dialogueText.text = messages[messageIndex];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);

        // 会話終了したら動きを戻す
        var pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = true;

        var myPc = player.GetComponent<MyPlayerController>();
        if (myPc != null) myPc.enabled = true;
    }
}