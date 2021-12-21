using UnityEngine;

namespace FlappyClone.Core
{
    // There are differently many other ways, patterns and tricks to accomplish 
    // "disable stuff on event" functionality. 
    // Having an abstract parent class just seems most readable to me. 
    // I instantly know what a class does if it has this parent.
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