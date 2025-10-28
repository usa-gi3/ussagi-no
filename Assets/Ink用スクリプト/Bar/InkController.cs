using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using System.Collections.Generic;

public class InkController : MonoBehaviour
{
    [Header("Ink")]
    public TextAsset inkJSONAsset;

    [Header("UI")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject choiceButtonPrefab;
    public Transform choiceButtonContainer;

    private Story story;

    void Start()
    {
        
    }


    public void StartDialogue()
    {
        Debug.Log("StartDialogueが呼ばれました");

        if (inkJSONAsset == null)
        {
            Debug.LogError("inkJSONAsset が設定されていません");
            return;
        }

        story = new Story(inkJSONAsset.text);

        int clear = TimeLimitManager.ClearFlag;

        if (clear == 1)
        {
            After_shop();
        }
        else
        {
            story.ChoosePathString("shop_intro");
        }


        dialoguePanel.SetActive(true);
        RefreshView();
    }

    void After_shop()
    {
        
        int Score = TimeLimitManager.ClearScore;


        if (Score == 0)
        {
            story.ChoosePathString("shop_after_1");
        }
        else if(Score>0&&Score<10)
        {
            story.ChoosePathString("shop_after_2");

        }
        else if (Score >= 10)
        {
            story.ChoosePathString("shop_after_3");
        }



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
