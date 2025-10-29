using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class InkController_Shop : MonoBehaviour
{
    [Header("Ink")]
    public TextAsset inkJSONAsset;

    [Header("UI")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject choiceButtonPrefab;
    public Transform choiceButtonContainer;

    private Story story;

    int clear = Point_Sum.ClearFlag_town;

    public void StartDialogue()
    {
        Debug.Log("StartDialogueが呼ばれました");

        if (inkJSONAsset == null)
        {
            Debug.LogError("inkJSONAsset が設定されていません");
            return;
        }

        story = new Story(inkJSONAsset.text);

        if (clear == 1)
        {
            story.ChoosePathString("Shop_after");

        }
        else
        {
            // Inkの特定パスから開始
             story.ChoosePathString("Shop_sun");
        }


        

        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    void ContinueStory()
    {
        if (story.canContinue)
        {
            string text = story.Continue().Trim();
            dialogueText.text = text;

            // タグをチェックしてシーン移動
            foreach (string tag in story.currentTags)
            {
                Debug.Log("Current Tag: " + tag);
                if (tag.StartsWith("scene:"))
                {
                    string sceneName = tag.Substring("scene:".Length).Trim();
                    Debug.Log("Loading Scene: " + sceneName);
                    SceneManager.LoadScene(sceneName);
                }
            }
        }

        RefreshChoices();
    }

    void RefreshChoices()
    {
        // 既存の選択肢を削除
        foreach (Transform child in choiceButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // 選択肢を生成
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            Choice choice = story.currentChoices[i];
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choiceButtonContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;

            int choiceIndex = i;
            buttonObj.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(choiceIndex));
        }

        // 選択肢がない場合は終了
        if (story.currentChoices.Count == 0 && !story.canContinue)
        {
            EndDialogue();
        }
    }

    void OnChoiceSelected(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
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
                ContinueStory();
        }
    }
}