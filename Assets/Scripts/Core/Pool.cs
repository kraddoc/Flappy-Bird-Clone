using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyClone.Core
{
    // Object pools are a must have optimization technique. 
    // Basically, instead of creating and destroying a bunch of
    // objects at runtime, we just get one from preinstantiated pool
    // and return it back when finished. It's useful with bullets,
    // enemies and stuff like obstacles in this game.
    public class Pool : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField, Range(1, 20)] private int poolSize;
        private readonly Queue<GameObject> _pool = new();

        private void Start()
        {
            CreatePool();
        }

        /// <summary>
        /// Returns game object from pool.
        /// </summary>
        public GameObject Get()
        {
            if(_pool.Count == 0)
                _pool.Enqueue(Instantiate(prefab, transform));
            return _pool.Dequeue();
        }
        /// <summary>
        /// Returns game object to pool, resets position and disables.
        /// </summary>
        public void Return(GameObject toReturn)
        {
            if (_pool.Contains(toReturn))
                throw new Exception("Trying to return game object already in pool.");
            _pool.Enqueue(toReturn);
            toReturn.transform.position = transform.position;
            toReturn.SetActive(false);
        }
        
        private void CreatePool()
        {
            for (var i = 0; i < poolSize; i++)
            {
                GameObject item = Instantiate(prefab, transform);
                _pool.Enqueue(item);
                item.gameObject.SetActive(false);
            }
        }
    }
}