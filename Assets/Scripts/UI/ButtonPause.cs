using System;
using UnityEngine;

namespace FlappyClone.UI
{
    public class ButtonPause : MonoBehaviour
    {
        public event Action OnPress;

        public void Pause()
        {                   
            OnPress?.Invoke();
        }
    }
}