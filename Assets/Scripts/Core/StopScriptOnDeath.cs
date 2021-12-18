using UnityEngine;

namespace FlappyClone.Core
{
    // There are differently many other ways, patterns and tricks to accomplish 
    // "disable stuff on event" functionality. 
    // This type of organization just seems like most readable to me. 
    public abstract class StopScriptOnDeath : MonoBehaviour
    {
        [SerializeField] private DeathToggle deathToggle;

        private protected void OnEnable()
        {
            deathToggle.OnDeath += Stop;
        }

        private protected virtual void OnDisable()
        {
            deathToggle.OnDeath -= Stop;
        }

        protected abstract void Stop();
    }
}