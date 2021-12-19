using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyClone.UI
{
    public class GameRestart : MonoBehaviour
    {
        // OG flappy bird doesn't actually have a restart - it kicks you
        // back to main menu after you lost. I'm pretty sure it's intentional.
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}