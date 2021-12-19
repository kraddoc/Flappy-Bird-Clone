using UnityEngine;

namespace FlappyClone.Visual.CameraShake
{
    public class Shake
    {
        private readonly float _duration; // Intended duration of shake.
        private float _lasted; // Amount of time passed since the start.
        private readonly float _strength;
        private AnimationCurve Curve { get; } // Animation curves are underappreciated. Use them for everything.

        // Originally, I just had Lasted and Duration public properties
        // and compared them in CameraShake class. It wouldn't cause
        // any problems, since the project is so small, but encapsulation
        // is good practice. Don't forget it.
        public bool StillShaking => _duration >= _lasted; 
        public float CurrentStrength => Curve.Evaluate(_lasted / _duration) * _strength;

        public Shake(float strength, float duration, AnimationCurve curve)
        {
            _strength = strength;
            _duration = duration;
            _lasted = 0;
            Curve = curve;
        }

        // Same as above, I just added delta time from CameraShake to a property
        // directly, but it's bad encapsulation. What if somewhere down the line
        // I'll add wrong value on accident? What if I add negative one?
        // Again, small game, it'll be fine in this exact case,
        // but it is a good practice, so please, encapsulate properly.
        public void FramePassed()
        {
            _lasted += Time.deltaTime;
        }
        
        
    }
}