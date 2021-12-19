using System;
using FlappyClone.Obstacles;
using UnityEngine;

namespace FlappyClone.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class ObstacleDetector : MonoBehaviour
    {
        public event Action OnObstacleCollision;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            ObstacleCheck(other.collider);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            ObstacleCheck(other);
        }

        private void ObstacleCheck(Collider2D other)
        {
            if (other.TryGetComponent(out Obstacle obstacle))
            {
                OnObstacleCollision?.Invoke();
            }
        }
    }
}