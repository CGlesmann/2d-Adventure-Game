using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionOptionManager : MonoBehaviour
{
    public delegate void OnInteractionSelect();

    [Header("Interaction Option Manager")]
    public GameObject interactionOptionPrefab;
    public GameObject interactionParent;
    private int currentlySelectedIndex = 0;

    [Header("Input Settings")]
    [SerializeField] private InputAction scrollAction;
    private Dictionary<string, OnInteractionSelect> interactionOptionMap;

    private void Awake()
    {
        InteractionOptionText newSelectedOptionText = interactionParent.transform.GetChild(0).GetComponent<InteractionOptionText>();
        newSelectedOptionText.SetAsSelected();
        currentlySelectedIndex = 0;

        scrollAction.performed += ExecuteScrollAction;
        scrollAction.Enable();
    }

    private void ExecuteScrollAction(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();

        if (value == -1)
        {
            if (currentlySelectedIndex < interactionParent.transform.childCount - 1)
            {
                UpdateCurrentSelectedOption(currentlySelectedIndex, ++currentlySelectedIndex);
            }
        }
        else if (value == 1)
        {
            if (currentlySelectedIndex > 0)
            {
                UpdateCurrentSelectedOption(currentlySelectedIndex, --currentlySelectedIndex);
            }
        }
    }

    private void UpdateCurrentSelectedOption(int oldTargetIndex, int newSelectedIndex)
    {
        InteractionOptionText currentlySelectedOptionText = interactionParent.transform.GetChild(oldTargetIndex).GetComponent<InteractionOptionText>();
        currentlySelectedOptionText.SetAsUnselected();

        InteractionOptionText newSelectedOptionText = interactionParent.transform.GetChild(newSelectedIndex).GetComponent<InteractionOptionText>();
        newSelectedOptionText.SetAsSelected();
        currentlySelectedIndex = newSelectedIndex;
    }

    public void AddNewInteractionOption(string optionDisplayText, OnInteractionSelect onInteractionSelect)
    {
        if (interactionOptionMap == null)
        {
            interactionOptionMap = new Dictionary<string, OnInteractionSelect>();
        }

        if (!interactionOptionMap.ContainsKey(optionDisplayText))
        {
            interactionOptionMap.Add(optionDisplayText, onInteractionSelect);

            GameObject newInteractionGameObject = GameObject.Instantiate(interactionOptionPrefab, interactionParent.transform);
            InteractionOptionText textComponent = newInteractionGameObject.GetComponent<InteractionOptionText>();

            if (textComponent != null)
            {
                textComponent.UpdateDisplayText(optionDisplayText);
                textComponent.onInteractSelect += ExecuteInteraction;
            }
        }
    }

    public InteractionOptionText GetCurrentlySelectedInteractionOption()
    {
        return interactionParent.transform.GetChild(currentlySelectedIndex).GetComponent<InteractionOptionText>();
    }

    public void ExecuteInteraction(string interaction)
    {
        if (interactionOptionMap.ContainsKey(interaction))
        {
            OnInteractionSelect interactionAction = interactionOptionMap[interaction];
            if (interactionAction != null)
            {
                interactionAction();
            }
        }
    }
}
