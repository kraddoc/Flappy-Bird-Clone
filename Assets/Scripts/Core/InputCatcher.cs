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

        //TODO: switch from onActionTriggered to actual onJump event.
        private void Start()
        {
            TryGetComponent(out _input);
            _input.onActionTriggered += ActionCaught;
        }

        private void ActionCaught(InputAction.CallbackContext obj)
        {
            if (obj.performed)
                OnJumpPress?.Invoke();
        }
    }
}