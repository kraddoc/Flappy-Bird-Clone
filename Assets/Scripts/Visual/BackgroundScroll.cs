using UnityEngine;

namespace FlappyClone.Visual
{
    // Move left, return to starting position once moved full sprite length.
    // """Parallax""" is achieved by setting speed value in editor, simple as.
    // There are more advanced ways to achieve it, like taking distance to camera
    // into account, but here it's overkill and introduces unnecessary dependencies.
    // Just, like, write a number, bro.
    // Fun fact: original Flappy Bird doesn't have background scrolling.
    // I was surprised when I found out.
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
