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

    private void Awake()
    {
        inputManager = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        animatorController = GetComponent<PlayerAnimatorController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (interactionLayer == (interactionLayer | (1 << other.gameObject.layer)))
        {
            InteractionManager interactionManager = other.GetComponent<InteractionManager>();
            if (interactionManager == null)
            {
                Debug.LogError($"Couldn't find an interaction manager on {other.name}");
                return;
            }

            this.interactionManager = interactionManager;
            inputManager.SubscribeToInputActionEvent(NPC_INTERACT_ACTION_KEY, OnInteract);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (interactionLayer == (interactionLayer | (1 << other.gameObject.layer)))
        {
            if (this.interactionManager != null && this.interactionManager == other.GetComponent<InteractionManager>())
            {
                this.interactionManager = null;
                inputManager.UnsubscribeToInputActionEvent(NPC_INTERACT_ACTION_KEY, OnInteract);
            }
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
        {
            // First NPC Interact
            if (!interactionInProgress && !interactionSelectionInProgress)
            {
                StartInteractionProcess();
                return;
            }

            // Select an Option
            if (interactionSelectionInProgress)
            {
                selectedInteraction = interactionManager.SelectCurrentlyHighlightedInteraction();
                selectedInteraction.BeginInteraction(EndInteractionProcess);

                interactionSelectionInProgress = false;
                interactionInProgress = true;

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

    public void StartInteractionProcess()
    {
        animatorController.DisableWalkAnimationUpdate();
        animatorController.SetCharacterToIdle();
        playerMovement.DisableWalking();
        interactionManager.EnableInteractionSelectionPanel();

        interactionSelectionInProgress = true;
    }

    public void EndInteractionProcess()
    {
        interactionInProgress = false;
        playerMovement.EnableWalking();
        animatorController.EnableWalkAnimationUpdate();
    }
}
