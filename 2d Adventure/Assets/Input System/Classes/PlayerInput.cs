// GENERATED AUTOMATICALLY FROM 'Assets/Input System/Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""862c8ea3-ff91-4461-bd2b-f376c01f5b83"",
            ""actions"": [
                {
                    ""name"": ""Walking"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e38713b6-0e61-4156-b3cb-95645b6e81c4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard_WASD"",
                    ""id"": ""a8467e43-5c3d-4230-8576-56380ad45cd3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""0defa904-64d1-4283-97b0-18a15bb3418d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""f42aeca9-02c3-40c9-93f8-034aec1282e0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""0786731d-a9d7-42b2-b327-725ca2b0173e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""b18d6243-42bb-47ad-b620-0012b8cd3dc3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""76f4c7da-8bfb-43d4-b086-33e5088a1108"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2,StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""d1b22104-1e12-4ba4-b634-4d13f28f5fe0"",
            ""actions"": [
                {
                    ""name"": ""NPC_Interact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""da245902-c650-4c0f-a640-63afa1a84c23"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f2b5f941-8402-4893-91f8-fcce98e26275"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""NPC_Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72c339dd-b13f-488d-bbd6-07a9c8e6a101"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NPC_Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""342b9810-e425-4e84-8488-499b02fc57a3"",
            ""actions"": [
                {
                    ""name"": ""ScrollOptions"",
                    ""type"": ""Value"",
                    ""id"": ""9bb928b1-d94f-489d-b666-5e462f75324a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""46e4c87c-f848-4d4b-a595-a80dad2909d5"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ScrollOptions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard_WASD"",
                    ""id"": ""96177635-1b2e-450a-add1-8bcf47b30753"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollOptions"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7c9256a7-c653-4b34-8e21-749916690f48"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollOptions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e40c2f46-eff4-438f-b931-15f164ea7cae"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""ScrollOptions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard_Mouse"",
            ""bindingGroup"": ""Keyboard_Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Walking = m_Movement.FindAction("Walking", throwIfNotFound: true);
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_NPC_Interact = m_Interaction.FindAction("NPC_Interact", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_ScrollOptions = m_UI.FindAction("ScrollOptions", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Walking;
    public struct MovementActions
    {
        private @PlayerInput m_Wrapper;
        public MovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walking => m_Wrapper.m_Movement_Walking;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Walking.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalking;
                @Walking.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalking;
                @Walking.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalking;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walking.started += instance.OnWalking;
                @Walking.performed += instance.OnWalking;
                @Walking.canceled += instance.OnWalking;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Interaction
    private readonly InputActionMap m_Interaction;
    private IInteractionActions m_InteractionActionsCallbackInterface;
    private readonly InputAction m_Interaction_NPC_Interact;
    public struct InteractionActions
    {
        private @PlayerInput m_Wrapper;
        public InteractionActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @NPC_Interact => m_Wrapper.m_Interaction_NPC_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
            {
                @NPC_Interact.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnNPC_Interact;
                @NPC_Interact.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnNPC_Interact;
                @NPC_Interact.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnNPC_Interact;
            }
            m_Wrapper.m_InteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NPC_Interact.started += instance.OnNPC_Interact;
                @NPC_Interact.performed += instance.OnNPC_Interact;
                @NPC_Interact.canceled += instance.OnNPC_Interact;
            }
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_ScrollOptions;
    public struct UIActions
    {
        private @PlayerInput m_Wrapper;
        public UIActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ScrollOptions => m_Wrapper.m_UI_ScrollOptions;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @ScrollOptions.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollOptions;
                @ScrollOptions.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollOptions;
                @ScrollOptions.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollOptions;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ScrollOptions.started += instance.OnScrollOptions;
                @ScrollOptions.performed += instance.OnScrollOptions;
                @ScrollOptions.canceled += instance.OnScrollOptions;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_Keyboard_MouseSchemeIndex = -1;
    public InputControlScheme Keyboard_MouseScheme
    {
        get
        {
            if (m_Keyboard_MouseSchemeIndex == -1) m_Keyboard_MouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard_Mouse");
            return asset.controlSchemes[m_Keyboard_MouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnWalking(InputAction.CallbackContext context);
    }
    public interface IInteractionActions
    {
        void OnNPC_Interact(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnScrollOptions(InputAction.CallbackContext context);
    }
}
