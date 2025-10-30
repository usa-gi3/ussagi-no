using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class InkController_Start : MonoBehaviour
{
    [Header("Ink")]
    public TextAsset inkJSONAsset;

    [Header("UI")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject choiceButtonPrefab;
    public Transform choiceButtonContainer;

    [Header("関連スクリプト")]
    public TalkTrigger_ookami talkTrigger;

    private Story story;

    public void StartDialogue()
    {
        Debug.Log("StartDialogueが呼ばれました");

        if (inkJSONAsset == null)
        {
            Debug.LogError("inkJSONAsset が設定されていません");
            return;
        }

        story = new Story(inkJSONAsset.text);

        story.ChoosePathString("New_Game");

        dialoguePanel.SetActive(true);
        RefreshView();
    }



    void RefreshView()
    {
        Debug.Log("選択肢の数：" + story.currentChoices.Count);

        // 1. セリフを表示
        if (story.canContinue)
        {
            string text = story.Continue().Trim();
            dialogueText.text = text.Replace("\n", "\n");
        }
        else if (story.currentChoices.Count == 0)
        {
            EndDialogue();
            return;
        }

        // 2. 既存の選択肢を削除
        foreach (Transform child in choiceButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // 3. 選択肢を生成
        foreach (Choice choice in story.currentChoices)
        {
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choiceButtonContainer);
            Debug.Log("ボタン生成: " + choice.text);

            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = choice.text;

            Button button = buttonObj.GetComponent<Button>();
            int choiceIndex = story.currentChoices.IndexOf(choice);
            button.onClick.AddListener(() => OnChoiceSelected(choiceIndex));
        }
        CheckForDestroyFlag();//破壊する
    }


    void OnChoiceSelected(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        RefreshView();
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Debug.Log("Dialogue ended.");
    }

    void CheckForDestroyFlag()
    {
        if (story != null && story.variablesState != null)
        {
            if (story.variablesState["delete_me"] != null &&
                (bool)story.variablesState["delete_me"])
            {
                Debug.Log("削除フラグ検知 → TalkTriggerに削除要求を送ります。");
                if (talkTrigger != null)
                {
                    talkTrigger.DestroySelf();
                }
                else
                {
                    Debug.LogWarning("talkTriggerが設定されていません。NPCを破壊できません。");
                }
            }
        }
    }

    void Update()
    {
        if (story == null || dialoguePanel == null)
            return;

        if (dialoguePanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (story.canContinue)
                RefreshView();
        }
    }

}
