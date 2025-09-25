using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class talknpc : MonoBehaviour
{
    public GameObject dialogueUI; // Canvas���̉�bUI���Z�b�g
    public TMP_Text dialogueText; // �Z���t�\���pText (TextMeshPro�Ȃ�TMP_Text�ɕύX)
    public string[] messages; // NPC�̃Z���t�ꗗ
    public GameObject player; //�v���C���[

    private bool playerInRange = false;
    private int messageIndex = 0;
    private bool isTalking = false;

    void Start()
    {
        dialogueUI.SetActive(false); // �Q�[���J�n���ɘg������
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("���������");
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

        // ��b���̓v���C���[�̓������~�߂�
        isTalking = true; messageIndex = 0; dialogueUI.SetActive(true); dialogueText.text = messages[messageIndex];
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

        // ��b�I�������瓮����߂�
        player.GetComponent<PlayerController>().enabled = true;
    }
}