using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInteraction : BaseInteraction
{
    [Header("Dialogue Settings")]
    [SerializeField] private DialogueConversation conversation;

    [Header("Object References")]
    [SerializeField] private DialogueTextManager dialogueTextManager;

    [Header("Input Settings")]
    [SerializeField] private InputAction progressAction;

    private int currentNodeIndex = -1;
    private bool dialogueInProgress = false;

    public override void OnInteractionBegin()
    {
        if (!dialogueInProgress)
        {
            dialogueTextManager.EnableDiagloueUI();
            //dialogueTextManager.UpdateDialogueText(conversation.conversationNodes[currentNodeIndex].nodeText);

            dialogueInProgress = true;
            progressAction.performed += ProgressDialogue;
            progressAction.Enable();
        }
    }

    public void ProgressDialogue(InputAction.CallbackContext context)
    {
        if (dialogueInProgress)
        {
            float inputValue = context.ReadValue<float>();

            Debug.Log(inputValue);
            if (inputValue == 1)
            {
                if (currentNodeIndex + 1 == conversation.conversationNodes.Count)
                {
                    dialogueTextManager.DisableDiagloueUI();
                    dialogueInProgress = false;

                    progressAction.performed -= ProgressDialogue;
                    progressAction.Disable();
                }
                else
                {
                    dialogueTextManager.UpdateDialogueText(conversation.conversationNodes[++currentNodeIndex].nodeText);
                }
            }
        }
    }
}
