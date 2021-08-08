using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionManager : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private LayerMask interactionLayer;

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

        inputManager.SubscribeToInputActionEvent("NPC_Interact", OnInteract);
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (interactionLayer == (interactionLayer | (1 << other.gameObject.layer)))
        {
            if (this.interactionManager != null && this.interactionManager == other.GetComponent<InteractionManager>())
            {
                this.interactionManager = null;
            }
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            // First NPC Interact
            if (!interactionInProgress && !interactionSelectionInProgress)
            {
                playerMovement.DisableWalking();
                interactionManager.EnableInteractionSelectionPanel();

                interactionSelectionInProgress = true;
                return;
            }

            // Select an Option
            if (interactionSelectionInProgress)
            {
                selectedInteraction = interactionManager.SelectCurrentlyHighlightedInteraction();
                selectedInteraction.BeginInteraction();

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

                    interactionInProgress = false;
                    playerMovement.EnableWalking();

                    return;
                }

                selectedInteraction.ProgressInteraction();
                return;
            }
        }
    }
}
