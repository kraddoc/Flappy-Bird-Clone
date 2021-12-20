using UnityEngine;

namespace FlappyClone.Core
{
    public abstract class PauseEventSubscriber : MonoBehaviour
    {
        [SerializeField] private PauseToggle pause;

        private void OnEnable()
        {
            pause.OnPause += Pause;
            pause.OnUnpause += Unpause;
        }
        
        private void OnDisable()
        {
            pause.OnPause -= Pause;
            pause.OnUnpause -= Unpause;
        }

        protected abstract void Pause();
        protected abstract void Unpause();
    }
}