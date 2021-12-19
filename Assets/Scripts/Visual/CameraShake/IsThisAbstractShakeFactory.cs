using UnityEngine;

namespace FlappyClone.Visual.CameraShake
{
    public abstract class IsThisAbstractShakeFactory : MonoBehaviour
    {                     // Actually, not at all. I just don't like code duplication.
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