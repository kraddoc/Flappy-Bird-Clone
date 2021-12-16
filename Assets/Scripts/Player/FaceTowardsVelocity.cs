using UnityEngine;

namespace FlappyClone.Player
{
    // This component smoothly rotates the rigidbody towards it's vertical velocity.
    [RequireComponent(typeof(Rigidbody2D))]
    public class FaceTowardsVelocity : MonoBehaviour
    {
        [SerializeField, Range(0f, 90f)] private float maxAngle = 75f;
        [SerializeField, Range(0f, 45f)] private float maxAngleOverhead = 20f;
        [SerializeField, Range(0f,-90f)] private float minAngle = -90f;
        [SerializeField, Range(0f, 100f)] private float rotationSpeed = 10f;
        [SerializeField, Range(0f, 1f)] private float negativeRotationMultiplier = 0.7f; //For slower downward rotation.
        [SerializeField, Range(0f, 1f)] private float smoothTime = 1f;
        
        private Rigidbody2D _rb2d;
        private float VerticalVelocity => _rb2d.velocity.y;
        private float _currentAngle; // Where we actually point.
        private float _targetAngle; // Where we want to point.
        private float _rotationVelocity;

        private void Start()
        {
            TryGetComponent(out _rb2d);
        }

        private void Update()
        {
            CalculateTargetAngle();
            CalculateCurrentAngle();
        }

        private void FixedUpdate()
        {
            _rb2d.rotation = _currentAngle;
        }

        /// <summary>
        /// If go up, target angle go up. If go down, target angle go down.
        /// </summary>
        private void CalculateTargetAngle()
        {
            var angleModifier = VerticalVelocity * rotationSpeed * Time.deltaTime;
            if (VerticalVelocity > 0)
                _targetAngle += angleModifier; 
            else
                _targetAngle += angleModifier * negativeRotationMultiplier; // I find it actually feels better if downward rotation is slightly slower.
            _targetAngle = Mathf.Clamp(_targetAngle, minAngle, maxAngle + maxAngleOverhead); // Clamping so it doesn't rotate infinitely. 
            // We clamp with overhead first. It won't be used for the real rotation, but it will make the bird point upwards for a bit even after it starts falling.
        }
        
        /// <summary>
        /// Calculating smooth transition between current and target angles.
        /// </summary>
        private void CalculateCurrentAngle()
        {
            _currentAngle =
                Mathf.SmoothDampAngle(_currentAngle, _targetAngle, ref _rotationVelocity, 
                    smoothTime); // Smoothing down the rotation a little bit.
            // The difference between SmoothDamp() and SmoothDampAngle() is what the latter runs Mathf.DeltaAngle() before calling the former,
            // so even weird angles like 1080 and 90 will return correct shortest rotation, which is 90. The more you know.
            _currentAngle = Mathf.Clamp(_currentAngle, minAngle, maxAngle); // Clamping angle again, but without overhead.
        }
    }
}
