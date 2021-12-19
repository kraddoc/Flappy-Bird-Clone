using UnityEngine;

namespace FlappyClone.Visual.CameraShake
{
    public abstract class IsThisAbstractShakeFactory : MonoBehaviour
    {                     // Uh... I don't know.
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float duration;
        [SerializeField] private float strength;
        [SerializeField] private CameraShake cameraShake;
        
        protected void Shake()
        {
            cameraShake.StartShake(new Shake(strength, duration, curve));
        }
    }
}