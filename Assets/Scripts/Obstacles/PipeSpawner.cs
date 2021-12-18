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

        private float _timer = 0f;
        private bool TimeToSpawn => _timer >= spawnTime;

        private void Update()
        {
            if (TimeToSpawn)
            {
                Spawn();
                _timer -= spawnTime;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }

        private void Spawn()
        {
            GameObject pipe = pool.Get();
            float offset = Random.Range(-maxVerticalOffset, maxVerticalOffset);
            Vector3 positionWithOffset = transform.position;
            positionWithOffset.y += offset;
            pipe.transform.position = positionWithOffset;
            pipe.SetActive(true);
        }
    }
}
