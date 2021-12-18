using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Audio
{
    public class DeathSound : PlaySound
    {
        [SerializeField] private DeathToggle deathToggle;

        private void OnEnable()
        {
            deathToggle.OnDeath += Play;
        }

        private void OnDisable()
        {
            deathToggle.OnDeath -= Play;
        }
    }
}