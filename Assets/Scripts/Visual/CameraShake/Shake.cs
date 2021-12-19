using UnityEngine;

namespace FlappyClone.Visual.CameraShake
{
    public class Shake
    {

        public float Duration { get; }
        public float Lasted { get; set; }
        public float CurrentStrength => Curve.Evaluate(Lasted / Duration) * _strength;
        private float _strength;
        private AnimationCurve Curve { get; }


        public Shake(float strength, float duration, AnimationCurve curve)
        {
            _strength = strength;
            Duration = duration;
            Lasted = 0;
            Curve = curve;
        }
        
        
    }
}