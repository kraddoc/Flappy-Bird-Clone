using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Visual.CameraShake
{
    public class CameraShakeOnDeath : IsThisAbstractShakeFactory
    {
        [SerializeField] private DeathToggle deathToggle;

        private void OnEnable()
        {
            deathToggle.OnDeath += Shake;
        }
        
        private void OnDisable()
        {
            deathToggle.OnDeath -= Shake;
        }
    }
}