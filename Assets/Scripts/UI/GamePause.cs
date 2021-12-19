using UnityEngine;

namespace FlappyClone.UI
{
    public class GamePause : MonoBehaviour
    {
        private bool _isPaused = false;
        
        // This really isn't the best way to pause a game,
        // but it works fine with this game.
        // I'm also pretty sure it's what the original uses.
        public void Pause()
        {                   
            Time.timeScale = _isPaused ? 1 : 0;
            _isPaused = !_isPaused;
        }
    }
}