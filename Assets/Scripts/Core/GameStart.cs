using FlappyClone.Obstacles;
using FlappyClone.Player;
using UnityEngine;

namespace FlappyClone.Core
{
    public class GameStart : MonoBehaviour
    {
        [SerializeField] private InputCatcher input;
        [SerializeField] private Rigidbody2D playerRigidbody2D;
        [SerializeField] private Flight playerFlight;
        [SerializeField] private PipeSpawner pipeSpawner;
        
        private void Start()
        {
            input.OnJumpPress += StartGame;
            pipeSpawner.enabled = false;
            playerFlight.enabled = false;
            playerRigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        private void StartGame()
        {
            playerRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            pipeSpawner.enabled = true;
            playerFlight.enabled = true;
            input.OnJumpPress -= StartGame;
        }
    }
}