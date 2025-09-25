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

    [SerializeField] private GameObject talkMark; // ��b�\�}�[�N
    [SerializeField] private Camera mainCamera;   // ���C���J����

    private bool playerInRange = false;
    private int messageIndex = 0;
    private bool isTalking = false;

    void Start()
    {
        dialogueUI.SetActive(false); // �Q�[���J�n���ɘg������
        if (talkMark != null) talkMark.SetActive(false);//�}�[�N���\����
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
        // �}�[�N���J�����̕����Ɍ�����
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
            if (talkMark != null) talkMark.SetActive(true); // �͈͂ɓ�������}�[�N�\��
            Debug.Log("���������");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (talkMark != null) talkMark.SetActive(false); // �͈͂���o�����\��
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

        // ��b�I�������瓮����߂�
        var pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = true;

        var myPc = player.GetComponent<MyPlayerController>();
        if (myPc != null) myPc.enabled = true;
    }
}