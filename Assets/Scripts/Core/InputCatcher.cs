using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FlappyClone.Core
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputCatcher : MonoBehaviour
    {
        public event Action OnJumpPress;
        private PlayerInput _input;
        
        private void Start()
        {
            TryGetComponent(out _input);
            _input.onActionTriggered += ActionCaught;
        }

        private void ActionCaught(InputAction.CallbackContext obj)
        {
            if (Time.timeScale == 0) return; // Quick and dirty check for pause.
            
            if (obj.performed) // Since there's only one input in existence, there's no need to check for specific event. 
                OnJumpPress?.Invoke(); 
        }
    }
}