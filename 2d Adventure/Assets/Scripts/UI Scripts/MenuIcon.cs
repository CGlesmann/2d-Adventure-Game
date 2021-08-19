using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuIcon : MonoBehaviour
{
    [Header("Icon Color Settings")]
    [SerializeField] private ColorBlock colors;
    private Image targetImage;

    private void Awake() { targetImage = GetComponent<Image>(); }

    public void SetMenuIconAsActive() { targetImage.color = colors.selectedColor; }
    public void SetMenuIconAsInactive() { targetImage.color = colors.normalColor; }
}
