using System;
using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Flight : MonoBehaviour
    {
        public event Action OnJump;
        
        [SerializeField] private float jumpStrength = 5f;
        [SerializeField] private InputCatcher input;
        private Rigidbody2D _rb2d;

        private void OnEnable()
        {
            TryGetComponent(out _rb2d);
            input.OnJumpPress += Jump;
            Jump(); // calling this here for the jump on first frame of gameplay.
        }

        private void OnDisable()
        {
            input.OnJumpPress -= Jump;
        }

        private void Jump()
        {
            StopFall();
            _rb2d.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse); 
            // There's no need to multiply by time delta, since the force is applied only once on button press.
            // In fact, multiplying by delta can actually make it more inconsistent with different framerates.
            OnJump?.Invoke();
        }
        
        
        private void StopFall()
        {
            // Setting velocity to zero when falling makes jump height more consistent. 
            if(_rb2d.velocity.y <= 0) 
             _rb2d.velocity = Vector2.zero;
        }
    }
}
