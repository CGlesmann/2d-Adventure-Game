using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueInteraction : BaseInteraction
{
    [Header("Object References")]
    [SerializeField] private DialogueTextManager dialogueTextManager;

    [Header("Dialogue Settings")]
    [SerializeField] private DialogueConversation conversation;

    private int currentNodeIndex;

    public override void BeginInteraction(UnityAction endAction)
    {
        base.BeginInteraction(endAction);
        currentNodeIndex = -1;

        dialogueTextManager.UpdateDialogueText(GetNextConversationNodeText());
        dialogueTextManager.EnableDiagloueUI();
    }

    public override void ProgressInteraction()
    {
        if (!canProgressInteraction)
            return;

        dialogueTextManager.UpdateDialogueText(GetNextConversationNodeText());
        return;
    }

    public override void EndInteraction()
    {
        base.EndInteraction();
        dialogueTextManager.DisableDiagloueUI();
    }

    public override bool IsInteractionComplete() { return IsOnLastConversationNode(); }

    private bool IsOnLastConversationNode() { return (currentNodeIndex + 1 == conversation.conversationNodes.Count); }
    private string GetNextConversationNodeText() { return conversation.conversationNodes[++currentNodeIndex].nodeText; }
}
