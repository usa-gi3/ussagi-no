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

    [Header("�֘A�X�N���v�g")]
    public TalkTrigger_ookami talkTrigger;

    private Story story;

    public void StartDialogue()
    {
        Debug.Log("StartDialogue���Ă΂�܂���");

        if (inkJSONAsset == null)
        {
            Debug.LogError("inkJSONAsset ���ݒ肳��Ă��܂���");
            return;
        }

        story = new Story(inkJSONAsset.text);

        story.ChoosePathString("New_Game");

        dialoguePanel.SetActive(true);
        RefreshView();
    }



    void RefreshView()
    {
        Debug.Log("�I�����̐��F" + story.currentChoices.Count);

        // 1. �Z���t��\��
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

        // 2. �����̑I�������폜
        foreach (Transform child in choiceButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // 3. �I�����𐶐�
        foreach (Choice choice in story.currentChoices)
        {
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choiceButtonContainer);
            Debug.Log("�{�^������: " + choice.text);

            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = choice.text;

            Button button = buttonObj.GetComponent<Button>();
            int choiceIndex = story.currentChoices.IndexOf(choice);
            button.onClick.AddListener(() => OnChoiceSelected(choiceIndex));
        }
        CheckForDestroyFlag();//�j�󂷂�
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
                Debug.Log("�폜�t���O���m �� TalkTrigger�ɍ폜�v���𑗂�܂��B");
                if (talkTrigger != null)
                {
                    talkTrigger.DestroySelf();
                }
                else
                {
                    Debug.LogWarning("talkTrigger���ݒ肳��Ă��܂���BNPC��j��ł��܂���B");
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
