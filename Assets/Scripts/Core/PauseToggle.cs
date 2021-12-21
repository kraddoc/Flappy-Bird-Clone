using UnityEngine;

namespace FlappyClone.Core
{
    public class PauseToggle : MonoBehaviour
    {
        private bool _paused;

        
        // Now, I believe manipulating timescale for pause functionality is bad.
        // Update still keeps running, maybe some stuff you don't want paused
        // is paused, you have to untether animations from scaled time, in short:
        // Stuff will break. 
        // Ideally you'd implement a state machine, custom time management utility
        // or swap Update for your own method, like Tick(), manage everything
        // individually and smash your head into the wall a few times,
        // but it's complete overkill in this case.
        // Here's some article I found which actually vouches FOR using timescale,
        // and explaining a few techniques on how to handle it correctly:
        // https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
        
        public void Toggle()
        {
            Time.timeScale = _paused ? 1 : 0;
            _paused = !_paused;
            AudioListener.pause = _paused;
        }
    }
}