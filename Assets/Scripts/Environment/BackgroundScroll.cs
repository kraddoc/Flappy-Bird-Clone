using System;
using Unity.VisualScripting;
using UnityEngine;

namespace FlappyClone.Environment
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundScroll : MonoBehaviour
    {
        [SerializeField, Range(0,15)] private float speed = 5f;
        [SerializeField, Range(0, 30)] private int tiles = 1;
        private Transform _tf;
        private SpriteRenderer _renderer;
        private float _width;
        private float _distanceTraveled;

        private void Start()
        {
            TryGetComponent(out _tf);
            TryGetComponent(out _renderer);
            _width = _renderer.size.x;
            CreateTiles();
        }

        private void Update()
        {
            if (_distanceTraveled >= _width)
            {
                var position = _tf.position;
                position.x += _distanceTraveled;
                _tf.position = position;
                _distanceTraveled = 0;
            }

            var speedDelta = speed * Time.deltaTime;
            _tf.Translate(Vector3.left * speedDelta);
            _distanceTraveled += speedDelta;
        }

        // That's a terrible one. It instantiates children of game object with the same sprite,
        // to fill the space original one leaves on the screen. It runs only once, so it's fine.
        private void CreateTiles()
        {
            var offset = _width;
            var position = _tf.position;
            for (var i = 0; i < tiles; i++)
            {
                position.x += offset;
                var tile = new GameObject();
                tile.transform.position = position;
                tile.transform.SetParent(_tf);
                tile.AddComponent<SpriteRenderer>().sprite = _renderer.sprite;
                tile.name = "Tile";
            }
        }
    }
}