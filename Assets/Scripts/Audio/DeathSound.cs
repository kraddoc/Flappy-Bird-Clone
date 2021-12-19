using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Audio
{
    public class DeathSound : PlaySound
    {
        [SerializeField] private DeathObserver deathObserver;

        private void OnEnable()
        {
            deathObserver.OnDeath += Play;
        }

        private void OnDisable()
        {
            deathObserver.OnDeath -= Play;
        }
    }
}