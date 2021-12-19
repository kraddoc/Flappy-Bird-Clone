using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Visual.CameraShake
{
    public class CameraShakeOnDeath : IsThisAbstractShakeFactory
    {
        [SerializeField] private DeathObserver deathObserver;

        private void OnEnable()
        {
            deathObserver.OnDeath += Shake;
        }
        
        private void OnDisable()
        {
            deathObserver.OnDeath -= Shake;
        }
    }
}