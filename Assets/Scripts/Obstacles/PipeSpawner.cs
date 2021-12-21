using System.Collections;
using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Obstacles
{
    // Just spawns pipe from pool with random vertical offset.
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 2f)] private float spawnTime = 1f;
        [SerializeField, Range(-5f, 5f)] private float maxVerticalOffset = 2.5f;
        [SerializeField] private Pool pool;

        private void OnEnable()
        {
            StartCoroutine(Spawn());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        // I originally just run a timer in update for this function, 
        // but I think coroutine is more elegant.
        private IEnumerator Spawn()
        {
            while (enabled) 
            {
                yield return new WaitForSeconds(spawnTime);
                var pipe = pool.Get();
                var offset = Random.Range(-maxVerticalOffset, maxVerticalOffset);
                var positionWithOffset = transform.position;
                positionWithOffset.y += offset;
                pipe.transform.position = positionWithOffset;
                pipe.SetActive(true);
            }
        }
    }
}
