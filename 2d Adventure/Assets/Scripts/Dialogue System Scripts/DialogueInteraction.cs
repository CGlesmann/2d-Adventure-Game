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

    public override void BeginInteraction(GameObject otherInteractor, UnityAction endAction)
    {
        base.BeginInteraction(otherInteractor, endAction);
        currentNodeIndex = -1;

        dialogueTextManager.StartConversation(conversation);
    }

    public override void ProgressInteraction()
    {
        if (!canProgressInteraction)
            return;

        dialogueTextManager.UpdateDialogueText();
        return;
    }

    public override void EndInteraction()
    {
        dialogueTextManager.DisableDiagloueUI();
        base.EndInteraction();
    }

    public override bool IsInteractionComplete() { return dialogueTextManager.IsConversationFinished(); }
    private string GetNextConversationNodeText() { return conversation.conversationNodes[++currentNodeIndex].nodeText; }
}
