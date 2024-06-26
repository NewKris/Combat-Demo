//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.2
//     from Assets/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine;

namespace CoffeeBara.Gameplay.Input
{
    public partial class @PlayerInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Locomotion"",
            ""id"": ""0faec1c9-4b77-4691-889c-f1bacd2bdd18"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""424c18a6-3210-438c-9b8c-50bf3809ca63"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9804bdd9-2e55-4587-b5aa-66e93e8a7134"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""0e9e8a09-9806-49ee-ab26-1c9a902aefe0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Value"",
                    ""id"": ""99d0aada-c392-448a-bbb7-5bd1df419419"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Detect"",
                    ""type"": ""Button"",
                    ""id"": ""76dcf867-9d7a-4fbc-9fba-6229b275d104"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""9f25e39f-6ec7-452f-8cfc-e7b6d44ab9af"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""add80826-10bf-47a2-870a-12e683ba8ae4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""faebd09b-ce02-4458-a790-acd2e8cea8d2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1ecc7a6c-7f74-4d69-bf9c-1a89494899d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""906ea0a8-ce48-412b-83d4-fc61151cd103"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""370d7ed2-000a-4e61-b978-9061f13fbdcd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e517a27-9326-4bfc-98f0-276f8eadb7d1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb323fe9-7032-423a-a5fa-b7f879823743"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""165d74e7-ea80-4a42-a344-bc44d4b1bf0d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd82dab6-ccd1-430e-ab6f-8332c40538bd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83a3609e-364f-452f-9e0e-9934815207fa"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55a0bcdf-38d1-4d37-b17f-4bcfbfa69295"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fff59983-45d0-40ee-9a6c-83d76aab35a2"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Detect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6b6c667-97c2-45be-b3b4-9f7a1abf8714"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Detect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""3eda0183-0939-4d00-814d-d94e9efea30c"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""ca20ee81-15f1-487f-986a-8859d9cc6b22"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""80e04e6c-901b-4664-9063-59d6f3a56918"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6233a6f0-2aeb-4975-b774-cc8719f18cbe"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3071299a-9f62-4180-be9e-f05e77b1feba"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a39593af-e955-4724-b62e-2c3397dfd390"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e57e052a-3116-4fd8-9032-c029361f6702"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Locomotion
            m_Locomotion = asset.FindActionMap("Locomotion", throwIfNotFound: true);
            m_Locomotion_Move = m_Locomotion.FindAction("Move", throwIfNotFound: true);
            m_Locomotion_Jump = m_Locomotion.FindAction("Jump", throwIfNotFound: true);
            m_Locomotion_Dash = m_Locomotion.FindAction("Dash", throwIfNotFound: true);
            m_Locomotion_Sprint = m_Locomotion.FindAction("Sprint", throwIfNotFound: true);
            m_Locomotion_Detect = m_Locomotion.FindAction("Detect", throwIfNotFound: true);
            // Combat
            m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
            m_Combat_Attack = m_Combat.FindAction("Attack", throwIfNotFound: true);
            m_Combat_Special = m_Combat.FindAction("Special", throwIfNotFound: true);
        }

        ~@PlayerInput()
        {
            Debug.Assert(!m_Locomotion.enabled, "This will cause a leak and performance issues, PlayerInput.Locomotion.Disable() has not been called.");
            Debug.Assert(!m_Combat.enabled, "This will cause a leak and performance issues, PlayerInput.Combat.Disable() has not been called.");
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Locomotion
        private readonly InputActionMap m_Locomotion;
        private List<ILocomotionActions> m_LocomotionActionsCallbackInterfaces = new List<ILocomotionActions>();
        private readonly InputAction m_Locomotion_Move;
        private readonly InputAction m_Locomotion_Jump;
        private readonly InputAction m_Locomotion_Dash;
        private readonly InputAction m_Locomotion_Sprint;
        private readonly InputAction m_Locomotion_Detect;
        public struct LocomotionActions
        {
            private @PlayerInput m_Wrapper;
            public LocomotionActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Locomotion_Move;
            public InputAction @Jump => m_Wrapper.m_Locomotion_Jump;
            public InputAction @Dash => m_Wrapper.m_Locomotion_Dash;
            public InputAction @Sprint => m_Wrapper.m_Locomotion_Sprint;
            public InputAction @Detect => m_Wrapper.m_Locomotion_Detect;
            public InputActionMap Get() { return m_Wrapper.m_Locomotion; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LocomotionActions set) { return set.Get(); }
            public void AddCallbacks(ILocomotionActions instance)
            {
                if (instance == null || m_Wrapper.m_LocomotionActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_LocomotionActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Detect.started += instance.OnDetect;
                @Detect.performed += instance.OnDetect;
                @Detect.canceled += instance.OnDetect;
            }

            private void UnregisterCallbacks(ILocomotionActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Dash.started -= instance.OnDash;
                @Dash.performed -= instance.OnDash;
                @Dash.canceled -= instance.OnDash;
                @Sprint.started -= instance.OnSprint;
                @Sprint.performed -= instance.OnSprint;
                @Sprint.canceled -= instance.OnSprint;
                @Detect.started -= instance.OnDetect;
                @Detect.performed -= instance.OnDetect;
                @Detect.canceled -= instance.OnDetect;
            }

            public void RemoveCallbacks(ILocomotionActions instance)
            {
                if (m_Wrapper.m_LocomotionActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ILocomotionActions instance)
            {
                foreach (var item in m_Wrapper.m_LocomotionActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_LocomotionActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public LocomotionActions @Locomotion => new LocomotionActions(this);

        // Combat
        private readonly InputActionMap m_Combat;
        private List<ICombatActions> m_CombatActionsCallbackInterfaces = new List<ICombatActions>();
        private readonly InputAction m_Combat_Attack;
        private readonly InputAction m_Combat_Special;
        public struct CombatActions
        {
            private @PlayerInput m_Wrapper;
            public CombatActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Attack => m_Wrapper.m_Combat_Attack;
            public InputAction @Special => m_Wrapper.m_Combat_Special;
            public InputActionMap Get() { return m_Wrapper.m_Combat; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
            public void AddCallbacks(ICombatActions instance)
            {
                if (instance == null || m_Wrapper.m_CombatActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_CombatActionsCallbackInterfaces.Add(instance);
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
            }

            private void UnregisterCallbacks(ICombatActions instance)
            {
                @Attack.started -= instance.OnAttack;
                @Attack.performed -= instance.OnAttack;
                @Attack.canceled -= instance.OnAttack;
                @Special.started -= instance.OnSpecial;
                @Special.performed -= instance.OnSpecial;
                @Special.canceled -= instance.OnSpecial;
            }

            public void RemoveCallbacks(ICombatActions instance)
            {
                if (m_Wrapper.m_CombatActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ICombatActions instance)
            {
                foreach (var item in m_Wrapper.m_CombatActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_CombatActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public CombatActions @Combat => new CombatActions(this);
        public interface ILocomotionActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnDetect(InputAction.CallbackContext context);
        }
        public interface ICombatActions
        {
            void OnAttack(InputAction.CallbackContext context);
            void OnSpecial(InputAction.CallbackContext context);
        }
    }
}
