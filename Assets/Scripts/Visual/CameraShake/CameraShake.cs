using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyClone.Visual.CameraShake
{
    // Originally I wanted camera shake to be just one simple script, but then realised
    // I never actually implemented any complex shake behaviours, so I decided to write one.
    // So, it just picks strongest current shake and applies it. 
    [RequireComponent(typeof(Camera))]
    public class CameraShake : MonoBehaviour
    {
        private readonly List<Shake> _shakes = new();
        private Vector3 _startingPosition;

        private void Start()
        {
            _startingPosition = transform.position;
        }

        public void StartShake(Shake shake)
        {
            _shakes.Add(shake);
            StopAllCoroutines();
            StartCoroutine(Shaking());
        }

        private IEnumerator Shaking()
        {
            while (_shakes.Count > 0)
            {
                transform.position = _startingPosition + (Vector3)(Random.insideUnitCircle * GetHighestShake());
                for (var i = 0; i < _shakes.Count; i++)     // foreach here would require allocating for additional list, 
                {                                           // since you can't modify a list from inside it's foreach loop.
                    var shake = _shakes[i];                 // This coroutine is already heavy enough as it is.
                    shake.Lasted += Time.deltaTime;
                    if (shake.Lasted > shake.Duration) _shakes.Remove(shake);
                }
                yield return null;
            }
        }

        private float GetHighestShake() => _shakes.Select(shake => shake.CurrentStrength).Prepend(0f).Max(); // God I love linq.
    }
}