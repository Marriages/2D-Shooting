//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/06_InputSystem/InputSystemController.inputactions
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

public partial class @InputSystemController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystemController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystemController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""8eb6555e-bb4c-4566-a6fc-a3ec27cba96d"",
            ""actions"": [
                {
                    ""name"": ""UDLR"",
                    ""type"": ""Value"",
                    ""id"": ""2ff630bf-36a7-4093-bc25-7f76a6505494"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""8b8bd215-3dae-4e37-9c49-1fa7e3908607"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpeedUp"",
                    ""type"": ""Button"",
                    ""id"": ""efe2fe8b-bd06-482b-bf57-f8021d36e450"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Bomb"",
                    ""type"": ""Button"",
                    ""id"": ""055cb1cc-f701-45f3-a56b-22791a9e53ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f325b429-b19d-4354-9328-071af71000d5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UDLR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""41f4e96d-b273-41c9-a345-a395c1c7a84d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""UDLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""135cf1d8-eff6-417b-9312-49337e2e2354"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""UDLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d3c29fa5-aad9-41ce-97a0-acf05fd1d3b1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""UDLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b786ee7c-57dc-4fd8-9814-4cb8a00894a4"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""UDLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ef10e8b1-1d00-4a8c-9203-98f13bd744dc"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c8fe1b7-2d61-4ae1-bdd5-665c9d49987d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""SpeedUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebc0f414-1962-4963-b5d2-1a196eb32669"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Bomb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Test"",
            ""id"": ""cd642587-7f5c-4068-8f6b-6739ef94699d"",
            ""actions"": [
                {
                    ""name"": ""Test1"",
                    ""type"": ""Button"",
                    ""id"": ""c5587808-c989-4b11-8ad1-ccf8b7d4f167"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test2"",
                    ""type"": ""Button"",
                    ""id"": ""fe05d04f-7678-4a91-8ba0-657ad65d41f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test3"",
                    ""type"": ""Button"",
                    ""id"": ""a3453b78-ba1a-4716-87f1-4e69d2e63ec0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test4"",
                    ""type"": ""Button"",
                    ""id"": ""1093f850-693e-4909-af63-1b99ad7d73e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test5"",
                    ""type"": ""Button"",
                    ""id"": ""10e639f8-b006-46b9-b8ca-80ad37b2d0df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test6"",
                    ""type"": ""Button"",
                    ""id"": ""e5fd8d92-1e99-455b-8e61-1d4f278008e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test7"",
                    ""type"": ""Button"",
                    ""id"": ""c1dbb62c-1a43-4c7f-9629-30025d1cc227"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d68c4b6a-9b52-4810-9f39-895446ec5ed1"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Test1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cc70903-acc1-4aa4-8451-086997cb6c02"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Test2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d9360bf-c178-48ed-bc2f-94b97a8f1ef7"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Test3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d56cf6a7-3c95-4ab9-8834-42dbdc72d104"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Test4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2d1527f-75d8-4225-a3e4-bd369063bae8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Test5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8a78756-6b51-4b8d-8a35-21c56db978f1"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Test6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bda41580-60f8-4dff-a3d6-6c468e47a8fd"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Test7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_UDLR = m_Player.FindAction("UDLR", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_SpeedUp = m_Player.FindAction("SpeedUp", throwIfNotFound: true);
        m_Player_Bomb = m_Player.FindAction("Bomb", throwIfNotFound: true);
        // Test
        m_Test = asset.FindActionMap("Test", throwIfNotFound: true);
        m_Test_Test1 = m_Test.FindAction("Test1", throwIfNotFound: true);
        m_Test_Test2 = m_Test.FindAction("Test2", throwIfNotFound: true);
        m_Test_Test3 = m_Test.FindAction("Test3", throwIfNotFound: true);
        m_Test_Test4 = m_Test.FindAction("Test4", throwIfNotFound: true);
        m_Test_Test5 = m_Test.FindAction("Test5", throwIfNotFound: true);
        m_Test_Test6 = m_Test.FindAction("Test6", throwIfNotFound: true);
        m_Test_Test7 = m_Test.FindAction("Test7", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_UDLR;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_SpeedUp;
    private readonly InputAction m_Player_Bomb;
    public struct PlayerActions
    {
        private @InputSystemController m_Wrapper;
        public PlayerActions(@InputSystemController wrapper) { m_Wrapper = wrapper; }
        public InputAction @UDLR => m_Wrapper.m_Player_UDLR;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @SpeedUp => m_Wrapper.m_Player_SpeedUp;
        public InputAction @Bomb => m_Wrapper.m_Player_Bomb;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @UDLR.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUDLR;
                @UDLR.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUDLR;
                @UDLR.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUDLR;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @SpeedUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpeedUp;
                @Bomb.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBomb;
                @Bomb.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBomb;
                @Bomb.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBomb;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UDLR.started += instance.OnUDLR;
                @UDLR.performed += instance.OnUDLR;
                @UDLR.canceled += instance.OnUDLR;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @SpeedUp.started += instance.OnSpeedUp;
                @SpeedUp.performed += instance.OnSpeedUp;
                @SpeedUp.canceled += instance.OnSpeedUp;
                @Bomb.started += instance.OnBomb;
                @Bomb.performed += instance.OnBomb;
                @Bomb.canceled += instance.OnBomb;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Test
    private readonly InputActionMap m_Test;
    private ITestActions m_TestActionsCallbackInterface;
    private readonly InputAction m_Test_Test1;
    private readonly InputAction m_Test_Test2;
    private readonly InputAction m_Test_Test3;
    private readonly InputAction m_Test_Test4;
    private readonly InputAction m_Test_Test5;
    private readonly InputAction m_Test_Test6;
    private readonly InputAction m_Test_Test7;
    public struct TestActions
    {
        private @InputSystemController m_Wrapper;
        public TestActions(@InputSystemController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Test1 => m_Wrapper.m_Test_Test1;
        public InputAction @Test2 => m_Wrapper.m_Test_Test2;
        public InputAction @Test3 => m_Wrapper.m_Test_Test3;
        public InputAction @Test4 => m_Wrapper.m_Test_Test4;
        public InputAction @Test5 => m_Wrapper.m_Test_Test5;
        public InputAction @Test6 => m_Wrapper.m_Test_Test6;
        public InputAction @Test7 => m_Wrapper.m_Test_Test7;
        public InputActionMap Get() { return m_Wrapper.m_Test; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestActions set) { return set.Get(); }
        public void SetCallbacks(ITestActions instance)
        {
            if (m_Wrapper.m_TestActionsCallbackInterface != null)
            {
                @Test1.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest1;
                @Test1.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest1;
                @Test1.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest1;
                @Test2.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest2;
                @Test2.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest2;
                @Test2.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest2;
                @Test3.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest3;
                @Test3.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest3;
                @Test3.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest3;
                @Test4.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest4;
                @Test4.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest4;
                @Test4.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest4;
                @Test5.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest5;
                @Test5.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest5;
                @Test5.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest5;
                @Test6.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest6;
                @Test6.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest6;
                @Test6.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest6;
                @Test7.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest7;
                @Test7.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest7;
                @Test7.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest7;
            }
            m_Wrapper.m_TestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Test1.started += instance.OnTest1;
                @Test1.performed += instance.OnTest1;
                @Test1.canceled += instance.OnTest1;
                @Test2.started += instance.OnTest2;
                @Test2.performed += instance.OnTest2;
                @Test2.canceled += instance.OnTest2;
                @Test3.started += instance.OnTest3;
                @Test3.performed += instance.OnTest3;
                @Test3.canceled += instance.OnTest3;
                @Test4.started += instance.OnTest4;
                @Test4.performed += instance.OnTest4;
                @Test4.canceled += instance.OnTest4;
                @Test5.started += instance.OnTest5;
                @Test5.performed += instance.OnTest5;
                @Test5.canceled += instance.OnTest5;
                @Test6.started += instance.OnTest6;
                @Test6.performed += instance.OnTest6;
                @Test6.canceled += instance.OnTest6;
                @Test7.started += instance.OnTest7;
                @Test7.performed += instance.OnTest7;
                @Test7.canceled += instance.OnTest7;
            }
        }
    }
    public TestActions @Test => new TestActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnUDLR(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSpeedUp(InputAction.CallbackContext context);
        void OnBomb(InputAction.CallbackContext context);
    }
    public interface ITestActions
    {
        void OnTest1(InputAction.CallbackContext context);
        void OnTest2(InputAction.CallbackContext context);
        void OnTest3(InputAction.CallbackContext context);
        void OnTest4(InputAction.CallbackContext context);
        void OnTest5(InputAction.CallbackContext context);
        void OnTest6(InputAction.CallbackContext context);
        void OnTest7(InputAction.CallbackContext context);
    }
}
