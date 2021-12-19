using System;
using FlappyClone.Player;
using UnityEngine;

namespace FlappyClone.Core
{
    public class DeathObserver : MonoBehaviour
    {
        public event Action OnDeath;

        [SerializeField] private ObstacleDetector detector;

        private bool _isDead;

        private void OnEnable()
        {
            detector.OnObstacleCollision += Die;
        }

        private void OnDisable()
        {
            detector.OnObstacleCollision -= Die;
        }
        
        private void Die()
        {
            if(_isDead) return;
            _isDead = true;
            OnDeath?.Invoke();
        }
    }
}