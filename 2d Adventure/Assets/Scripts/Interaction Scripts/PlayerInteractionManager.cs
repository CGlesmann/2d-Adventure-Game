using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionManager : MonoBehaviour
{
    private const string NPC_INTERACT_ACTION_KEY = "NPC_Interact";

    [Header("Interaction Settings")]
    [SerializeField] private LayerMask interactionLayer;

    private PlayerAnimatorController animatorController;
    private PlayerInputManager inputManager;
    private PlayerMovement playerMovement;
    private InteractionManager interactionManager;
    private BaseInteraction selectedInteraction;

    private bool interactionSelectionInProgress;
    private bool interactionInProgress;
    private bool subscribedInputInteraction;

    private void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        animatorController = GetComponent<PlayerAnimatorController>();

        subscribedInputInteraction = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!subscribedInputInteraction && interactionLayer == (interactionLayer | (1 << other.gameObject.layer)))
        {
            InteractionManager interactionManager = other.GetComponent<InteractionManager>();
            if (interactionManager == null)
            {
                Debug.LogError($"Couldn't find an interaction manager on {other.name}");
                return;
            }

            this.interactionManager = interactionManager;
            subscribedInputInteraction = true;
            inputManager.SubscribeToInputActionEvent(NPC_INTERACT_ACTION_KEY, OnInteract);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (interactionLayer == (interactionLayer | (1 << other.gameObject.layer)))
        {
            if (subscribedInputInteraction || (this.interactionManager != null && this.interactionManager == other.GetComponent<InteractionManager>()))
            {
                ResetInteractionState();
            }
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (interactionManager != null)
        {
            if (context.ReadValue<float>() == 0)
            {
                // First NPC Interact
                if (!interactionInProgress && !interactionSelectionInProgress)
                {
                    StartInteractionProcess();

                    BaseInteraction interaction = interactionManager.InitiateInteractionSelection();
                    if (interaction != null)
                    {
                        StartInteraction();

                        selectedInteraction = interaction;
                        selectedInteraction.BeginInteraction(gameObject, EndInteractionProcess);

                        return;
                    }

                    return;
                }

                // Select an Option
                if (interactionSelectionInProgress)
                {
                    selectedInteraction = interactionManager.SelectCurrentlyHighlightedInteraction();
                    selectedInteraction.BeginInteraction(gameObject, EndInteractionProcess);

                    StartInteraction();
                    return;
                }

                // Progress Interaction
                if (interactionInProgress)
                {
                    if (selectedInteraction.IsInteractionComplete())
                    {
                        selectedInteraction.EndInteraction();
                        return;
                    }

                    selectedInteraction.ProgressInteraction();
                    return;
                }
            }
        }
    }

    public void StartInteractionProcess()
    {
        animatorController.DisableWalkAnimationUpdate();
        animatorController.SetCharacterToIdle();
        playerMovement.DisableWalking();

        interactionSelectionInProgress = true;
    }

    public void StartInteraction()
    {
        interactionSelectionInProgress = false;
        interactionInProgress = true;
    }

    public void EndInteractionProcess()
    {
        playerMovement.EnableWalking();
        animatorController.EnableWalkAnimationUpdate();

        interactionInProgress = false;
    }

    public void UnsubscribeInteractionAction() { inputManager.UnsubscribeToInputActionEvent(NPC_INTERACT_ACTION_KEY, OnInteract); }
    public void ResetInteractionState()
    {
        this.interactionManager = null;
        subscribedInputInteraction = false;
        UnsubscribeInteractionAction();
    }
}
