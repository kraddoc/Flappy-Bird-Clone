using UnityEngine;

namespace FlappyClone.Visual
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HorizontalTiler : MonoBehaviour
    {
        [SerializeField, Range(0, 30)] private int tiles = 1;
        private Transform _tf;
        private SpriteRenderer _renderer;
        private float _width;
        
        private void Start()
        {
            TryGetComponent(out _tf);
            TryGetComponent(out _renderer);
            _width = _renderer.size.x;
            CreateTiles();
        }
        
        // That's a bad one. It instantiates children of game object with the same sprite,
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