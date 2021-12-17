using System;
using FlappyClone.Environment;
using UnityEngine;

namespace FlappyClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Scorer : MonoBehaviour
    {
        public event Action OnScored;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PipesZone _))
            {
                OnScored?.Invoke();
            }
        }
    }
}
