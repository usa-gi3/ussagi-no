using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class talknpcmain : MonoBehaviour
{
    public GameObject dialogueUI;     // Canvas���̉�bUI
    public TMP_Text dialogueText;     // �Z���t�\���p
    public GameObject player;

    private bool playerInRange = false;
    private bool isTalking = false;
    private int messageIndex = 0;

    // �Z���t�f�[�^
    [System.Serializable]
    public class DialogueLine
    {        
        public string Text;
    }

    private List<DialogueLine> messages = new List<DialogueLine>();

    void Start()
    {
        dialogueUI.SetActive(false);

        // �� CSV�����[�h���Ă���NPC�p�̃Z���t��ǂݍ��ށi��: npcname.csv�j
        LoadCSV("npcA_dialogue");
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTalking)
                StartDialogue();
            else
                NextMessage();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            EndDialogue();
        }
    }

    void LoadCSV(string fileName)
    {
        TextAsset csvFile = Resources.Load<TextAsset>(fileName);
        if (csvFile == null)
        {
            Debug.LogError("CSV�t�@�C����������܂���: " + fileName);
            return;
        }

        string[] lines = csvFile.text.Split('\n');
        for (int i = 1; i < lines.Length; i++) // 1�s�ڂ̓w�b�_�z��
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            string[] values = lines[i].Split(',');
            DialogueLine line = new DialogueLine();
            line.Text = values[1];
            messages.Add(line);
        }
    }

    void StartDialogue()
    {
        isTalking = true;
        messageIndex = 0;
        dialogueUI.SetActive(true);
        ShowMessage();

        // ��b���̓v���C���[�̓������~�߂�
        var pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = false;

        var myPc = player.GetComponent<MyPlayerController>();
        if (myPc != null) myPc.enabled = false;
    }

    void NextMessage()
    {
        messageIndex++;
        if (messageIndex < messages.Count)
            ShowMessage();
        else
            EndDialogue();
    }

    void ShowMessage()
    {
        dialogueText.text = messages[messageIndex].Text;
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
