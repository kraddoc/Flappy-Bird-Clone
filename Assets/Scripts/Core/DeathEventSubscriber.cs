using UnityEngine;

namespace FlappyClone.Core
{
    // There are differently many other ways, patterns and tricks to accomplish 
    // "disable stuff on event" functionality. 
    // This type of organization just seems like most readable to me. 
    public abstract class DeathEventSubscriber : MonoBehaviour
    {
        [SerializeField] private DeathObserver deathObserver;

        private protected void OnEnable()
        {
            deathObserver.OnDeath += Stop;
        }

        private protected virtual void OnDisable()
        {
            deathObserver.OnDeath -= Stop;
        }

        protected abstract void Stop();
    }
}