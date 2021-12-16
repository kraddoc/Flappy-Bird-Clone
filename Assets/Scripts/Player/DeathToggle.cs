using System;
using System.Collections;
using FlappyClone.Controls;
using UnityEngine;

namespace FlappyClone.Player
{
    [RequireComponent(typeof(ObstacleDetector), typeof(Flight), typeof(Rigidbody2D))]
    public class DeathToggle : MonoBehaviour
    {
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
            print("Player has died.");
            _flight.enabled = false;
            _isDead = true;
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