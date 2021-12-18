using FlappyClone.Player;
using UnityEngine;

namespace FlappyClone.Audio
{
    public class HitSound : PlaySound
    {
        [SerializeField] private ObstacleDetector obstacleDetector;

        private void OnEnable()
        {
            obstacleDetector.OnObstacleCollision += Play;
        }

        private void OnDisable()
        {
            obstacleDetector.OnObstacleCollision -= Play;
        }
    }
}