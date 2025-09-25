using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class talknpcmain : MonoBehaviour
{
    public GameObject dialogueUI;     // Canvas内の会話UI
    public TMP_Text dialogueText;     // セリフ表示用
    public GameObject player;

    private bool playerInRange = false;
    private bool isTalking = false;
    private int messageIndex = 0;

    // セリフデータ
    [System.Serializable]
    public class DialogueLine
    {        
        public string Text;
    }

    private List<DialogueLine> messages = new List<DialogueLine>();

    void Start()
    {
        dialogueUI.SetActive(false);

        // ★ CSVをロードしてこのNPC用のセリフを読み込む（例: npcname.csv）
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
            Debug.LogError("CSVファイルが見つかりません: " + fileName);
            return;
        }

        string[] lines = csvFile.text.Split('\n');
        for (int i = 1; i < lines.Length; i++) // 1行目はヘッダ想定
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

        // 会話中はプレイヤーの動きを止める
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

        // 会話終了したら動きを戻す
        var pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = true;

        var myPc = player.GetComponent<MyPlayerController>();
        if (myPc != null) myPc.enabled = true;
    }
}
