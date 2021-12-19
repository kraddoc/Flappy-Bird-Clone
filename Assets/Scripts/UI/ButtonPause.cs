using System;
using UnityEngine;

namespace FlappyClone.UI
{
    public class ButtonPause : MonoBehaviour
    {
        public event Action OnPause;
        public event Action OnUnpause;
        
        private bool _isPaused;
        
        public void Pause()
        {                   
            if(_isPaused) OnUnpause?.Invoke();
            else OnPause?.Invoke();
        }
    }
}