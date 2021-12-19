using System;
using FlappyClone.Player;
using UnityEngine;

namespace FlappyClone.Visual.CameraShake
{
    public class CameraShakeOnHit : IsThisAbstractShakeFactory
    {
        [SerializeField] private ObstacleDetector obstacleDetector;

        private void OnEnable()
        {
            obstacleDetector.OnObstacleCollision += Shake;
        }
        
        private void OnDisable()
        {
            obstacleDetector.OnObstacleCollision -= Shake;
        }
    }
}