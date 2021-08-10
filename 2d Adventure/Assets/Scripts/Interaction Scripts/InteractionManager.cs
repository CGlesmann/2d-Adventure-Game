using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("Object References")]
    public GameObject interactionOptionManagerObject;
    [SerializeField] private Transform interactionComponentParent;

    private InteractionOptionManager interactionOptionManager;

    public void EnableInteractionSelectionPanel() { interactionOptionManagerObject.SetActive(true); }
    public void DisableInteractionSelectionPanel() { interactionOptionManagerObject.SetActive(false); }

    private void Awake()
    {
        interactionOptionManager = interactionOptionManagerObject.GetComponent<InteractionOptionManager>();

        for (int i = 0; i < interactionComponentParent.childCount; i++)
        {
            BaseInteraction interaction = interactionComponentParent.GetChild(i).GetComponent<BaseInteraction>();
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
