using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Obstacles
{
    // Returns pipes to pool on collision.
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class PipeDespawner : MonoBehaviour
    {
        [SerializeField] private Pool pool;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PipesZone pipe))
            {
                pool.Return(pipe.gameObject);
            }

        }
    }
}