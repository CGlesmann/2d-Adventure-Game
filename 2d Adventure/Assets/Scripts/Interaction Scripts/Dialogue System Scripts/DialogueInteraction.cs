using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : BaseInteraction
{
    [Header("Object References")]
    [SerializeField] private DialogueTextManager dialogueTextManager;

    [Header("Dialogue Settings")]
    [SerializeField] private DialogueConversation conversation;

    private int currentNodeIndex;

    public override void BeginInteraction()
    {
        currentNodeIndex = -1;

        dialogueTextManager.UpdateDialogueText(GetNextConversationNodeText());
        dialogueTextManager.EnableDiagloueUI();
    }

    public override void ProgressInteraction()
    {
        dialogueTextManager.UpdateDialogueText(GetNextConversationNodeText());
        return;
    }

    public override bool IsInteractionComplete() { return IsOnLastConversationNode(); }
    public override void EndInteraction() { dialogueTextManager.DisableDiagloueUI(); }

    private bool IsOnLastConversationNode() { return (currentNodeIndex + 1 == conversation.conversationNodes.Count); }
    private string GetNextConversationNodeText() { return conversation.conversationNodes[++currentNodeIndex].nodeText; }
}
