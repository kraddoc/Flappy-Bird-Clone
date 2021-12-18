using System;
using FlappyClone.Player;
using UnityEngine;

namespace FlappyClone.Visual
{
    [RequireComponent(typeof(ParticleSystem))]
    public class HitParticles : MonoBehaviour
    {
        [SerializeField] private ObstacleDetector obstacleDetector;

        private ParticleSystem _particles;

        private void Start()
        {
            TryGetComponent(out _particles);
        }

        private void OnEnable()
        {
            obstacleDetector.OnObstacleCollision += Launch;
        }

        private void OnDisable()
        {
            obstacleDetector.OnObstacleCollision -= Launch;
        }

        private void Launch()
        {
            _particles.Play();
        }
    }
}