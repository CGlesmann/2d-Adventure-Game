using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public delegate void OnInteractionEnd();
    public event OnInteractionEnd onInteractionEnd;

    public GameObject interactionOptionManagerObject;

    private Component[] interactions;
    private InteractionOptionManager interactionOptionManager;

    private void Awake() 
    {
        interactionOptionManager = interactionOptionManagerObject.GetComponent<InteractionOptionManager>();
        interactions = this.GetComponents(typeof(BaseInteraction));

        foreach (BaseInteraction interaction in interactions)
        {
            interactionOptionManager.AddNewInteractionOption(interaction.interactionDisplayText, interaction.OnInteractionBegin);
        }

        DisableInteractionPanel();
    }

    public void EnableInteractionPanel() 
    {
        interactionOptionManagerObject.SetActive(true);
    }

    public void DisableInteractionPanel() 
    {
        interactionOptionManagerObject.SetActive(false);
    }

    public void ExecuteCurrentlySelectedInteraction()
    {
        InteractionOptionText currentlySelectedOption = interactionOptionManager.GetCurrentlySelectedInteractionOption();

        DisableInteractionPanel();
        currentlySelectedOption.SelectOption();
    }

    public void FinishInteraction()
    {
        if (onInteractionEnd != null)
        {
            onInteractionEnd();
        }

        DisableInteractionPanel();
    }
}
