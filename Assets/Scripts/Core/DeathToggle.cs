using System;
using FlappyClone.Obstacles;
using FlappyClone.Player;
using FlappyClone.Visual;
using UnityEngine;

namespace FlappyClone.Core
{
    public class DeathToggle : MonoBehaviour
    {
        public event Action OnDeath;

        [SerializeField] private ObstacleDetector detector;
        [SerializeField] private Flight flight;

        private bool _isDead;

        private void OnEnable()
        {
            detector.OnObstacleCollision += Die;
        }

        private void OnDisable()
        {
            detector.OnObstacleCollision -= Die;
        }

        // TODO: this is trash.
        private void Die()
        {
            if(_isDead) return;
            _isDead = true;
            flight.enabled = false;
            foreach (var o in FindObjectsOfType(typeof(PipeHorizontalMovement), true))
            {
                var pipe = (PipeHorizontalMovement) o;
                pipe.enabled = false;
            }
            foreach (var o in FindObjectsOfType(typeof(BackgroundScroll), true))
            {
                var scroll = (BackgroundScroll) o;
                scroll.enabled = false;
            }
            OnDeath?.Invoke();
        }
    }
}