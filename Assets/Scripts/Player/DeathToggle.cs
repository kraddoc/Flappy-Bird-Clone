using System;
using System.Collections;
using FlappyClone.Controls;
using UnityEngine;

namespace FlappyClone.Player
{
    //TODO: Refactor this.
    [RequireComponent(typeof(ObstacleDetector), typeof(Flight), typeof(Rigidbody2D))]
    public class DeathToggle : MonoBehaviour
    {
        public event Action OnDeath;
        
        [SerializeField] private InputCatcher inputCatcher; //TODO: remove later
        private ObstacleDetector _detector;
        private Flight _flight;
        private Vector3 _startingPosition;
        private bool _isDead = false;

        private void OnEnable()
        {
            _startingPosition = transform.position;
            TryGetComponent(out _flight);
            TryGetComponent(out _detector);
            _detector.OnObstacleCollision += Die;
            inputCatcher.OnJumpPress += Resurrect;
        }

        private void OnDisable()
        {
            _detector.OnObstacleCollision -= Die;
            inputCatcher.OnJumpPress -= Resurrect;
        }

        private void Die()
        {
            if (_isDead) return;
            print("Player has died.");
            _flight.enabled = false;
            _isDead = true;
            OnDeath?.Invoke();
        }

        private void Resurrect()
        {
            if (!_isDead) return;
            print("Player has resurrected.");
            _flight.enabled = true;
            transform.position = _startingPosition;
            _isDead = false;
        }
    }
}