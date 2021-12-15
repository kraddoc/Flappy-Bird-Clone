using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FlappyClone.Player
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
            if (obj.performed)
                OnJumpPress?.Invoke();
        }
    }
}