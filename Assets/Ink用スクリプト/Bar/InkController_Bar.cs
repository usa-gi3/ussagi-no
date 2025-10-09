using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InkController_Bar : MonoBehaviour
{
    [Header("Ink")]
    public TextAsset inkJSONAsset;

    [Header("UI")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject choiceButtonPrefab;
    public Transform choiceButtonContainer;

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
        story.ChoosePathString("order_start");

        dialoguePanel.SetActive(true);
        ContinueStory(); // 最初のセリフを表示
    }

    void ContinueStory()
    {
        if (story.canContinue)
        {
            string text = story.Continue().Trim();
            dialogueText.text = text.Replace("\n", "\n");

            // タグをチェックしてシーン移動
            foreach (string tag in story.currentTags)
            {
                if (tag.StartsWith("scene:"))
                {
                    string sceneName = tag.Substring("scene:".Length);
                    SceneManager.LoadScene(sceneName);
                }
            }

            RefreshView(); // 選択肢がある場合は表示
        }
    }

    void RefreshView()
    {
        Debug.Log("選択肢の数：" + story.currentChoices.Count);

        if (!story.canContinue && story.currentChoices.Count == 0)
        {
            EndDialogue();
            return;
        }

        // 既存の選択肢を削除
        foreach (Transform child in choiceButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // 選択肢を生成
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
        ContinueStory(); // 選択後にセリフを進める
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
                ContinueStory(); // クリックでセリフを進める
        }
    }
}
