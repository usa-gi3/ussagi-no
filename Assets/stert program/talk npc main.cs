using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class talknpcmain : MonoBehaviour
{
    public GameObject dialogueUI;     // Canvas���̉�bUI
    public TMP_Text dialogueText;     // �Z���t�\���p
    public GameObject player;

    [SerializeField] private GameObject talkMark; // ��b�\�}�[�N
    [SerializeField] private Camera mainCamera;   // ���C���J����

    private bool playerInRange = false;
    private bool isTalking = false;
    private int messageIndex = 0;

    // �Z���t�f�[�^
    [System.Serializable]
    public class DialogueLine
    {
        public int EventID;
        public int Progress;
        public string Text;
        public string NextID;
    }

    private List<DialogueLine> messages = new List<DialogueLine>();

    void Start()
    {
        dialogueUI.SetActive(false);
        if (talkMark != null) talkMark.SetActive(false);//�}�[�N���\����
        // CSV�����[�h���Ă���NPC�p�̃Z���t��ǂݍ���
        LoadCSV("sinariodeta1-2");
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

    private void LateUpdate()
    {
        // �}�[�N���J�����̕����Ɍ�����
        if (talkMark != null && talkMark.activeSelf)
        {
            talkMark.transform.LookAt(talkMark.transform.position + mainCamera.transform.forward);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (talkMark != null) talkMark.SetActive(true); // �͈͂ɓ�������}�[�N�\��
        }
            
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (talkMark != null) talkMark.SetActive(false); // �͈͂���o�����\��
            EndDialogue();
        }
    }

    /// <summary>
    /// CSV�ǂݍ���
    /// </summary>
    void LoadCSV(string fileName)
    {
        TextAsset csvFile = Resources.Load<TextAsset>(fileName);

        string[] lines = csvFile.text.Split('\n');
        for (int i = 1; i < lines.Length; i++) // 1�s�ڂ̓w�b�_
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            // Excel��TSV�ۑ��Ȃ�^�u��؂�ɕς���
            string[] values = lines[i].Trim().Split(',');

            if (values.Length < 3) continue;

            DialogueLine line = new DialogueLine();

            if (int.TryParse(values[0].Trim(), out int eventId))
                line.EventID = eventId;
            else
                continue;

            if (int.TryParse(values[1].Trim(), out int progress))
                line.Progress = progress;
            else
                continue;

            line.Text = values[2].Trim();

            if (values.Length > 3)
                line.NextID = values[3].Trim();

            messages.Add(line);
        }
    }

    /// <summary>
    /// ��b�J�n
    /// </summary>
    void StartDialogue()
    {
        isTalking = true; 
        messageIndex = 0;
        dialogueUI.SetActive(true); 
        ShowMessage();

        //�v���C���[���~�߂�
        var pc = player.GetComponent<PlayerController>(); 
        if (pc != null) pc.enabled = false;

        var myPc = player.GetComponent<MyPlayerController>();
        if (myPc != null) myPc.enabled = false;
    }

    /// <summary>
    /// ���̃��b�Z�[�W��
    /// </summary>
    void NextMessage()
    {
        messageIndex++;
        if (messageIndex < messages.Count)
            ShowMessage();
        else
            EndDialogue();
    }

    /// <summary>
    /// �Z���t�\��
    /// </summary>
    void ShowMessage()
    {
        if (messageIndex < 0 || messageIndex >= messages.Count)
        {
            Debug.LogError("������ messageIndex: " + messageIndex);
            EndDialogue();
            return;
        }

        var line = messages[messageIndex];
        dialogueText.text = line.Text;

        if (!string.IsNullOrEmpty(line.NextID))
        {
            string[] next = line.NextID.Split(',');
            if (next.Length == 1)
            {
                // Progress�ԍ���T���Ď����J��
                if (int.TryParse(next[0], out int nextProgress))
                {
                    var nextLine = messages.Find(m => m.Progress == nextProgress);
                    if (nextLine != null)
                        messageIndex = messages.IndexOf(nextLine);
                }
            }
            else
            {
                // �I������\��
                ShowChoices(next);
            }
        }
    }

    /// <summary>
    /// �I������\���i���̓��O�ɏo�������j
    /// </summary>
    void ShowChoices(string[] nextProgresses)
    {
        for (int i = 0; i < nextProgresses.Length; i++)
        {
            if (int.TryParse(nextProgresses[i], out int nextId))
            {
                string choiceText = messages.Find(m => m.Progress == nextId)?.Text;
                Debug.Log($"�I���� {i + 1}: {choiceText}");
            }
        }
    }

    /// <summary>
    /// �I������I�񂾂Ƃ�
    /// </summary>
    void OnChoiceSelected(int chosenProgress)
    {
        var nextLine = messages.Find(m => m.Progress == chosenProgress);
        if (nextLine != null)
        {
            messageIndex = messages.IndexOf(nextLine);
            ShowMessage();
        }
    }

    /// <summary>
    /// ��b�I��
    /// </summary>
    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);

        // �v���C���[�̑����߂�
        var pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = true;

        var myPc = player.GetComponent<MyPlayerController>();
        if (myPc != null) myPc.enabled = true;
    }
}
