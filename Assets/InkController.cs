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
    public TextMeshProUGUI dialogueText; // TMP�p�ɕύX
    public GameObject choiceButtonPrefab; // TMP�Ή���Button�v���n�u
    public Transform choiceButtonContainer;

    private Story story;

    void Start()
    {
        story = new Story(inkJSONAsset.text);
        RefreshView();
    }

    void RefreshView()
    {
        // �Z���t�\��
        if (story.canContinue)
        {
            string text = story.Continue().Trim();
            dialogueText.text = text;
        }

        // �����̑I�������폜
        foreach (Transform child in choiceButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // �I�����\��
        if (story.currentChoices.Count > 0)
        {
            foreach (Choice choice in story.currentChoices)
            {
                GameObject buttonObj = Instantiate(choiceButtonPrefab, choiceButtonContainer);
                TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = choice.text;

                Button button = buttonObj.GetComponent<Button>();
                button.onClick.AddListener(() => OnChoiceSelected(choice.index));
            }
        }
    }

    void OnChoiceSelected(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        RefreshView();
    }
}