using FlappyClone.Core;

namespace FlappyClone.Visual
{
    public class PauseBackground : PauseEventSubscriber
    {
        protected override void Pause()
        {
            foreach (var o in FindObjectsOfType(typeof(BackgroundScroll), true))
            {
                var scroll = (BackgroundScroll) o;
                scroll.enabled = false;
            }
        }

        protected override void Unpause()
        {
            foreach (var o in FindObjectsOfType(typeof(BackgroundScroll), true))
            {
                var scroll = (BackgroundScroll) o;
                scroll.enabled = true;
            }
        }
    }
}