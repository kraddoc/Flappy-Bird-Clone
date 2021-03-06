using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyClone.Core
{
    public class LevelRestart : MonoBehaviour
    {
        // OG flappy bird doesn't actually have a restart - it kicks you
        // back to main menu after you lost. I got irritated a little every time
        // it made me go through the menu again.
        // I'm pretty sure it's intentional.
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}