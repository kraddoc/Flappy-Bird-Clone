using UnityEngine;

namespace FlappyClone.Environment
{
    // I never know how to name those scripts.
    public class PipeHorizontalMovement : MonoBehaviour
    {

        [SerializeField] private float speed = 5f;
        private Transform _tf;

        private void Start()
        {
            TryGetComponent(out _tf);
        }

        private void Update()
        {
            _tf.Translate(Vector3.left * speed * Time.deltaTime); // It just works.
        }
    }
}
