using UnityEngine;

namespace FlappyClone.Environment
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundScroll : MonoBehaviour
    {
        [SerializeField, Range(0,15)] private float speed = 5f;
        private Transform _tf;
        private float _width;
        private float _distanceTraveled;
        private bool TraveledFullDistance => _distanceTraveled >= _width;

        private void Start()
        {
            TryGetComponent(out _tf);
            TryGetComponent(out SpriteRenderer spriteRenderer);
            _width = spriteRenderer.size.x;
        }

        private void Update()
        {
            if (TraveledFullDistance)
            {
                ResetPosition();
            }

            var speedDelta = speed * Time.deltaTime;
            _tf.Translate(Vector3.left * speedDelta);
            _distanceTraveled += speedDelta;
        }

        private void ResetPosition()
        {
            var position = _tf.position;
            position.x += _distanceTraveled;
            _tf.position = position;
            _distanceTraveled = 0;
        }
    }
}