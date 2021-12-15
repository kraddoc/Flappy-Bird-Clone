using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace FlappyClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Flight : MonoBehaviour
    {
        [SerializeField] private float jumpStrength = 5f;
        
        [SerializeField] private InputCatcher input;
        private Rigidbody2D _rb2d;

        private void Start()
        {
            TryGetComponent(out _rb2d);
            if (!TryGetComponent(out input))
                throw new Exception("No input catcher found on jump script.");
        }

        public void Jump()
        {
            print("Jump.");
            _rb2d.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
    }
}
