using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("Object References")]
    public GameObject interactionOptionManagerObject;
    [SerializeField] private Transform interactionComponentParent;

    private InteractionOptionManager interactionOptionManager;

    public void EnableInteractionSelectionPanel() { interactionOptionManagerObject?.SetActive(true); }
    public void DisableInteractionSelectionPanel() { interactionOptionManagerObject?.SetActive(false); }

    private void Awake()
    {
        interactionOptionManager = interactionOptionManagerObject.GetComponent<InteractionOptionManager>();
        if (interactionOptionManager == null)
        {
            Debug.LogWarning($"No Interaction Option Manager Was found for {gameObject.name}");
            return;
        }

        for (int i = 0; i < interactionComponentParent.childCount; i++)
        {
            BaseInteraction interaction = interactionComponentParent.GetChild(i).GetComponent<BaseInteraction>();
            interactionOptionManager.AddNewInteractionOption(interaction.interactionDisplayText, interaction);
        }
    }

    public BaseInteraction SelectCurrentlyHighlightedInteraction()
    {
        DisableInteractionSelectionPanel();
        return interactionOptionManager.GetCurrentlySelectedInteractionOption();
    }

    public BaseInteraction InitiateInteractionSelection()
    {
        if (interactionComponentParent.childCount > 1 || interactionComponentParent.childCount == 0)
        {
            EnableInteractionSelectionPanel();
            return null;
        }

        return interactionComponentParent.GetChild(0).GetComponent<BaseInteraction>();
    }
}
