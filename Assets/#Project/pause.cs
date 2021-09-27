// GENERATED AUTOMATICALLY FROM 'Assets/#Project/pause.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Pause : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Pause()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""pause"",
    ""maps"": [
        {
            ""name"": ""timeChange"",
            ""id"": ""c2d310fd-63fb-4f8e-8c99-9694b9c1962a"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""67bfd80a-ad92-44de-ad96-1415b25b62a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""30d00c37-60dc-4ba6-bd3c-cd030bf2986b"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // timeChange
        m_timeChange = asset.FindActionMap("timeChange", throwIfNotFound: true);
        m_timeChange_Pause = m_timeChange.FindAction("Pause", throwIfNotFound: true);
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

    // timeChange
    private readonly InputActionMap m_timeChange;
    private ITimeChangeActions m_TimeChangeActionsCallbackInterface;
    private readonly InputAction m_timeChange_Pause;
    public struct TimeChangeActions
    {
        private @Pause m_Wrapper;
        public TimeChangeActions(@Pause wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_timeChange_Pause;
        public InputActionMap Get() { return m_Wrapper.m_timeChange; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TimeChangeActions set) { return set.Get(); }
        public void SetCallbacks(ITimeChangeActions instance)
        {
            if (m_Wrapper.m_TimeChangeActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_TimeChangeActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_TimeChangeActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_TimeChangeActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_TimeChangeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public TimeChangeActions @timeChange => new TimeChangeActions(this);
    public interface ITimeChangeActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
