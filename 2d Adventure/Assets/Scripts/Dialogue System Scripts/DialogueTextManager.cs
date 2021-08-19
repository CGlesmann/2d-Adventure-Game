using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTextManager : MonoBehaviour
{
    [Header("Dialogue Settings")]
    [SerializeField] private float dialogueTypeDelay;

    [Header("UI References")]
    [SerializeField] private GameObject dialogueParentObject;
    [SerializeField] private TextMeshProUGUI dialogueTextElement;

    private Coroutine typingCoroutine;
    private DialogueConversation conversation;
    private string targetFinalDialogueString;
    private int currentConversationNode;

    public void EnableDiagloueUI() { dialogueParentObject.SetActive(true); }
    public void DisableDiagloueUI() { dialogueParentObject.SetActive(false); }

    public void StartConversation(DialogueConversation conversation)
    {
        this.conversation = conversation;

        currentConversationNode = 0;
        targetFinalDialogueString = conversation.conversationNodes[0].nodeText;
        dialogueTextElement.text = "";

        EnableDiagloueUI();
        typingCoroutine = StartCoroutine(TypeDialogueNodeText());
    }

    public void UpdateDialogueText()
    {
        if (conversation == null) { return; }

        // Progress to next node
        if (dialogueTextElement.text == targetFinalDialogueString)
        {
            targetFinalDialogueString = conversation.conversationNodes[++currentConversationNode].nodeText;
            dialogueTextElement.text = "";

            if (currentConversationNode == conversation.conversationNodes.Count - 1) { conversation = null; }

            typingCoroutine = StartCoroutine(TypeDialogueNodeText());
            return;
        }

        // Current node in progress, Automatically complete current node
        if (dialogueTextElement.text.Length < targetFinalDialogueString.Length)
        {
            StopCoroutine(typingCoroutine);
            dialogueTextElement.text = targetFinalDialogueString;
            return;
        }
    }

    private IEnumerator TypeDialogueNodeText()
    {
        dialogueTextElement.text = "";
        foreach (char c in targetFinalDialogueString)
        {
            dialogueTextElement.text += c;
            yield return new WaitForSeconds(dialogueTypeDelay);
        }
    }

    public bool IsConversationFinished()
    {
        return (
            conversation == null ||
            currentConversationNode >= conversation.conversationNodes.Count
        );
    }
}
