using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class talknpc : MonoBehaviour
{
    public GameObject dialogueUI; // Canvas内の会話UIをセット
    public TMP_Text dialogueText;     // セリフ表示用Text (TextMeshProならTMP_Textに変更)
    public string[] messages;     // NPCのセリフ一覧
    public GameObject player;   //プレイヤー

    private bool playerInRange = false;
    private int messageIndex = 0;
    private bool isTalking = false;

    // Update is called once per frame
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("判定入った");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
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
        player.GetComponent<move>().enabled = false;
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
        player.GetComponent<move>().enabled = true;
    }
}
