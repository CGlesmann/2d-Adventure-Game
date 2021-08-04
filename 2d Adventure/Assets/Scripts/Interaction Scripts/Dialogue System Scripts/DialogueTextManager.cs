using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTextManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject dialogueParentObject;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public void EnableDiagloueUI() { dialogueParentObject.SetActive(true); }
    public void DisableDiagloueUI() { dialogueParentObject.SetActive(false); }

    public void UpdateDialogueText(string newText)
    {
        dialogueText.text = newText;
    }
}
