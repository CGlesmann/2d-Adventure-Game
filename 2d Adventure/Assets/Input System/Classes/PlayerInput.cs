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
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""2888a5c3-902c-437a-a921-104e1b6bc3b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
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
                },
                {
                    ""name"": """",
                    ""id"": ""693f337e-1cf7-4cad-bf17-89c3918c91e7"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebed2166-ce43-42b2-a080-f9534c4226b7"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""0e734c13-e75a-4546-9851-401ff5c1fefd"",
            ""actions"": [
                {
                    ""name"": ""Sword_Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b3465700-9bbf-4f6f-9967-df76ace710cb"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f1520dd0-bfc4-483f-a077-37601e38241a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Sword_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b895adb8-873c-441d-97cc-8b2d0d5572b0"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sword_Attack"",
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
                    ""name"": ""UIScroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9bb928b1-d94f-489d-b666-5e462f75324a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UICancel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""66b4b84d-a2c8-4bb5-894f-dcbe73b31717"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UIMenuActiveToggle"",
                    ""type"": ""PassThrough"",
                    ""id"": ""250b6c90-e83b-4091-befd-ceb13d7d8832"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UIMenuNavigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""79af15b8-af2a-457b-81d9-b126a9078688"",
                    ""expectedControlType"": ""Analog"",
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
                    ""action"": ""UIScroll"",
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
                    ""action"": ""UIScroll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7c9256a7-c653-4b34-8e21-749916690f48"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""UIScroll"",
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
                    ""action"": ""UIScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8b08f45a-7bee-413a-b702-f0cfd0d05c17"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""UICancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f4c7e3b-3268-4873-baed-49b641b39d0b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UICancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca9081c6-25d8-47f7-8b8f-7c8112dd3189"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""UIMenuActiveToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48a53b56-69cd-4455-bcc1-7517b4a31b6d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UIMenuActiveToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad_Bumpers"",
                    ""id"": ""69e4be64-2dcc-4109-be17-4ee98b60ed83"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIMenuNavigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4bb894ee-0e13-4502-91ed-19449a5482fc"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UIMenuNavigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""beaf040e-19cb-4fe3-b1b9-2cbf47c881b6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UIMenuNavigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard_ZX"",
                    ""id"": ""75089199-927d-4ccc-810a-8f11adc1b38e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIMenuNavigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""23d2e675-ee65-403b-8964-89f76966ff15"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""UIMenuNavigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""00619e04-0ff1-456a-a574-68b996b337f8"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""UIMenuNavigate"",
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
        m_Movement_Dash = m_Movement.FindAction("Dash", throwIfNotFound: true);
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_Sword_Attack = m_Combat.FindAction("Sword_Attack", throwIfNotFound: true);
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_NPC_Interact = m_Interaction.FindAction("NPC_Interact", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_UIScroll = m_UI.FindAction("UIScroll", throwIfNotFound: true);
        m_UI_UICancel = m_UI.FindAction("UICancel", throwIfNotFound: true);
        m_UI_UIMenuActiveToggle = m_UI.FindAction("UIMenuActiveToggle", throwIfNotFound: true);
        m_UI_UIMenuNavigate = m_UI.FindAction("UIMenuNavigate", throwIfNotFound: true);
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
    private readonly InputAction m_Movement_Dash;
    public struct MovementActions
    {
        private @PlayerInput m_Wrapper;
        public MovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walking => m_Wrapper.m_Movement_Walking;
        public InputAction @Dash => m_Wrapper.m_Movement_Dash;
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
                @Dash.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walking.started += instance.OnWalking;
                @Walking.performed += instance.OnWalking;
                @Walking.canceled += instance.OnWalking;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_Sword_Attack;
    public struct CombatActions
    {
        private @PlayerInput m_Wrapper;
        public CombatActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Sword_Attack => m_Wrapper.m_Combat_Sword_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @Sword_Attack.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSword_Attack;
                @Sword_Attack.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSword_Attack;
                @Sword_Attack.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSword_Attack;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Sword_Attack.started += instance.OnSword_Attack;
                @Sword_Attack.performed += instance.OnSword_Attack;
                @Sword_Attack.canceled += instance.OnSword_Attack;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);

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
    private readonly InputAction m_UI_UIScroll;
    private readonly InputAction m_UI_UICancel;
    private readonly InputAction m_UI_UIMenuActiveToggle;
    private readonly InputAction m_UI_UIMenuNavigate;
    public struct UIActions
    {
        private @PlayerInput m_Wrapper;
        public UIActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @UIScroll => m_Wrapper.m_UI_UIScroll;
        public InputAction @UICancel => m_Wrapper.m_UI_UICancel;
        public InputAction @UIMenuActiveToggle => m_Wrapper.m_UI_UIMenuActiveToggle;
        public InputAction @UIMenuNavigate => m_Wrapper.m_UI_UIMenuNavigate;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @UIScroll.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUIScroll;
                @UIScroll.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUIScroll;
                @UIScroll.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUIScroll;
                @UICancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUICancel;
                @UICancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUICancel;
                @UICancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUICancel;
                @UIMenuActiveToggle.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUIMenuActiveToggle;
                @UIMenuActiveToggle.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUIMenuActiveToggle;
                @UIMenuActiveToggle.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUIMenuActiveToggle;
                @UIMenuNavigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUIMenuNavigate;
                @UIMenuNavigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUIMenuNavigate;
                @UIMenuNavigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUIMenuNavigate;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UIScroll.started += instance.OnUIScroll;
                @UIScroll.performed += instance.OnUIScroll;
                @UIScroll.canceled += instance.OnUIScroll;
                @UICancel.started += instance.OnUICancel;
                @UICancel.performed += instance.OnUICancel;
                @UICancel.canceled += instance.OnUICancel;
                @UIMenuActiveToggle.started += instance.OnUIMenuActiveToggle;
                @UIMenuActiveToggle.performed += instance.OnUIMenuActiveToggle;
                @UIMenuActiveToggle.canceled += instance.OnUIMenuActiveToggle;
                @UIMenuNavigate.started += instance.OnUIMenuNavigate;
                @UIMenuNavigate.performed += instance.OnUIMenuNavigate;
                @UIMenuNavigate.canceled += instance.OnUIMenuNavigate;
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
        void OnDash(InputAction.CallbackContext context);
    }
    public interface ICombatActions
    {
        void OnSword_Attack(InputAction.CallbackContext context);
    }
    public interface IInteractionActions
    {
        void OnNPC_Interact(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnUIScroll(InputAction.CallbackContext context);
        void OnUICancel(InputAction.CallbackContext context);
        void OnUIMenuActiveToggle(InputAction.CallbackContext context);
        void OnUIMenuNavigate(InputAction.CallbackContext context);
    }
}
