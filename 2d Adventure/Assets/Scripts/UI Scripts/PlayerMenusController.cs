using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMenusController : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private GameObject playerMenusCanvas;
    [SerializeField] private Transform playerMenusParent;
    [SerializeField] private Transform playerMenuIconsParent;

    private PlayerMovement playerMovement;
    private MenuIcon[] playerMenuIcons;
    private int currentActiveMenuIndex = 0;

    private void OnEnable()
    {
        playerInputManager.SubscribeToInputActionEvent("UIMenuActiveToggle", TogglePlayerMenuCanvas);

        if (playerMenuIconsParent != null && playerMenuIconsParent.childCount > 0)
        {
            playerMenuIcons = new MenuIcon[playerMenuIconsParent.childCount];
            for (int i = 0; i < playerMenuIconsParent.childCount; i++)
            {
                playerMenuIcons[i] = playerMenuIconsParent.GetChild(i).GetComponent<MenuIcon>();
            }
        }
    }

    private void OnDisable()
    {
        playerInputManager.UnsubscribeToInputActionEvent("UIMenuActiveToggle", TogglePlayerMenuCanvas);
        if (playerMenusCanvas.activeSelf)
        {
            playerInputManager.UnsubscribeToInputActionEvent("UIMenuNavigate", ToggleActiveMenu);
        }
    }

    public void TogglePlayerMenuCanvas(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
        {
            if (playerMenusCanvas == null || playerMenusParent == null) { return; }

            playerMenusCanvas.SetActive(!playerMenusCanvas.activeSelf);

            if (playerMenusCanvas.activeSelf)
            {
                if (playerMovement == null) { playerMovement = gameObject.GetComponent<PlayerMovement>(); }
                playerMovement.DisableWalking();

                currentActiveMenuIndex = 0;
                SetTargetMenuToActive(currentActiveMenuIndex);

                playerInputManager.SubscribeToInputActionEvent("UIMenuNavigate", ToggleActiveMenu);
            }
            else
            {
                playerInputManager.UnsubscribeToInputActionEvent("UIMenuNavigate", ToggleActiveMenu);

                if (playerMovement == null) { playerMovement = gameObject.GetComponent<PlayerMovement>(); }
                playerMovement.EnableWalking();

                SetTargetMenuToInactive(currentActiveMenuIndex);
            }
        }
    }

    public void ToggleActiveMenu(InputAction.CallbackContext context)
    {
        float inputValue = context.ReadValue<float>();
        int targetIndex = (int)Mathf.Clamp(currentActiveMenuIndex + inputValue, 0, playerMenusParent.childCount - 1);

        if (targetIndex != currentActiveMenuIndex)
        {
            SetTargetMenuToInactive(currentActiveMenuIndex);
            currentActiveMenuIndex = targetIndex;
            SetTargetMenuToActive(currentActiveMenuIndex);
        }
    }

    public void SetTargetMenuToActive(int targetMenuIndex)
    {
        playerMenusParent.GetChild(targetMenuIndex).gameObject.SetActive(true);
        playerMenuIcons[targetMenuIndex].SetMenuIconAsActive();
    }

    public void SetTargetMenuToInactive(int targetMenuIndex)
    {
        playerMenusParent.GetChild(targetMenuIndex).gameObject.SetActive(false);
        playerMenuIcons[targetMenuIndex].SetMenuIconAsInactive();
    }
}
