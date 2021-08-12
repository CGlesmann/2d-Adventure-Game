using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuScreen : MonoBehaviour
{
    [Header("Screen References")]
    [SerializeField] private Selectable defaultObjectToSelect;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(defaultObjectToSelect.gameObject);
    }
}
