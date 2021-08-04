using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionOptionText : MonoBehaviour
{
    public delegate void OnInteractOptionSelect(string interactionText);
    public event OnInteractOptionSelect onInteractSelect;

    [Header("Selection Options")]
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color defaultColor;

    private TextMeshProUGUI cachedTextComponent;
    private TextMeshProUGUI optionDisplayText {
        get {
            if (cachedTextComponent == null)
                cachedTextComponent = GetComponent<TextMeshProUGUI>();

            return cachedTextComponent;
        }
    }

    public void UpdateDisplayText(string newDisplayText) { optionDisplayText.text = newDisplayText; }
    public void SetAsSelected() { optionDisplayText.color = selectedColor; }
    public void SetAsUnselected() { optionDisplayText.color = defaultColor; }

    public void SelectOption()
    {
        if (onInteractSelect != null)
        {
            onInteractSelect(optionDisplayText.text);
        }
    }
}
