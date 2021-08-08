using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("Object References")]
    public GameObject interactionOptionManagerObject;

    private Component[] interactions;
    private InteractionOptionManager interactionOptionManager;

    public void EnableInteractionSelectionPanel() { interactionOptionManagerObject.SetActive(true); }
    public void DisableInteractionSelectionPanel() { interactionOptionManagerObject.SetActive(false); }

    private void Awake()
    {
        interactionOptionManager = interactionOptionManagerObject.GetComponent<InteractionOptionManager>();
        interactions = this.GetComponents(typeof(BaseInteraction));

        foreach (BaseInteraction interaction in interactions)
        {
            interactionOptionManager.AddNewInteractionOption(interaction.interactionDisplayText, interaction);
        }

        DisableInteractionSelectionPanel();
    }

    public BaseInteraction SelectCurrentlyHighlightedInteraction()
    {
        DisableInteractionSelectionPanel();
        return interactionOptionManager.GetCurrentlySelectedInteractionOption();
    }
}
