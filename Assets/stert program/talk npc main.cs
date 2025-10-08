using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class talknpcmain : MonoBehaviour
{
    public GameObject dialogueUI;     // Canvas内の会話UI
    public TMP_Text dialogueText;     // セリフ表示用
    public GameObject player;

    [SerializeField] private GameObject talkMark; // 会話可能マーク
    [SerializeField] private Camera mainCamera;   // メインカメラ

    private bool playerInRange = false;
    private bool isTalking = false;
    private int messageIndex = 0;

    // セリフデータ
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
        if (talkMark != null) talkMark.SetActive(false);//マークを非表示に
        // CSVをロードしてこのNPC用のセリフを読み込む
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
        // マークをカメラの方向に向ける
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
            if (talkMark != null) talkMark.SetActive(true); // 範囲に入ったらマーク表示
        }
            
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (talkMark != null) talkMark.SetActive(false); // 範囲から出たら非表示
            EndDialogue();
        }
    }

    /// <summary>
    /// CSV読み込み
    /// </summary>
    void LoadCSV(string fileName)
    {
        TextAsset csvFile = Resources.Load<TextAsset>(fileName);

        string[] lines = csvFile.text.Split('\n');
        for (int i = 1; i < lines.Length; i++) // 1行目はヘッダ
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            // ExcelのTSV保存ならタブ区切りに変える
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
    /// 会話開始
    /// </summary>
    void StartDialogue()
    {
        isTalking = true; 
        messageIndex = 0;
        dialogueUI.SetActive(true); 
        ShowMessage();

        //プレイヤーを止める
        var pc = player.GetComponent<PlayerController>(); 
        if (pc != null) pc.enabled = false;

        var myPc = player.GetComponent<MyPlayerController>();
        if (myPc != null) myPc.enabled = false;
    }

    /// <summary>
    /// 次のメッセージへ
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
    /// セリフ表示
    /// </summary>
    void ShowMessage()
    {
        if (messageIndex < 0 || messageIndex >= messages.Count)
        {
            Debug.LogError("無効な messageIndex: " + messageIndex);
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
                // Progress番号を探して自動遷移
                if (int.TryParse(next[0], out int nextProgress))
                {
                    var nextLine = messages.Find(m => m.Progress == nextProgress);
                    if (nextLine != null)
                        messageIndex = messages.IndexOf(nextLine);
                }
            }
            else
            {
                // 選択肢を表示
                ShowChoices(next);
            }
        }
    }

    /// <summary>
    /// 選択肢を表示（今はログに出すだけ）
    /// </summary>
    void ShowChoices(string[] nextProgresses)
    {
        for (int i = 0; i < nextProgresses.Length; i++)
        {
            if (int.TryParse(nextProgresses[i], out int nextId))
            {
                string choiceText = messages.Find(m => m.Progress == nextId)?.Text;
                Debug.Log($"選択肢 {i + 1}: {choiceText}");
            }
        }
    }

    /// <summary>
    /// 選択肢を選んだとき
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
    /// 会話終了
    /// </summary>
    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);

        // プレイヤーの操作を戻す
        var pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = true;

        var myPc = player.GetComponent<MyPlayerController>();
        if (myPc != null) myPc.enabled = true;
    }
}
