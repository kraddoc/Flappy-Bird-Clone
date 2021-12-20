using System;
using FlappyClone.UI;
using UnityEngine;

namespace FlappyClone.Core
{
    public class PauseToggle : MonoBehaviour
    {
        public event Action OnPause;
        public event Action OnUnpause;
        
        [SerializeField] private ButtonPause button;
        [SerializeField] private DeathObserver death;

        private bool _paused;
        
        private void OnEnable()
        {
            button.OnPress += Toggle;
            death.OnDeath += DisableSelf;
        }

        private void OnDisable()
        {
            button.OnPress -= Toggle;
            death.OnDeath -= DisableSelf;
        }

        private void Toggle()
        {
            if (_paused) OnUnpause?.Invoke();
            else OnPause?.Invoke();

            _paused = !_paused;
        }

        private void DisableSelf()
        {
            enabled = false;
        }
    }
}