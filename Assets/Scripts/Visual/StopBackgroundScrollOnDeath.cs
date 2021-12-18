using FlappyClone.Core;

namespace FlappyClone.Visual
{
    public class StopBackgroundScrollOnDeath : StopScriptOnDeath
    {
        protected override void Stop()
        {
            foreach (var o in FindObjectsOfType(typeof(BackgroundScroll), true))
            {
                var scroll = (BackgroundScroll) o;
                scroll.enabled = false;
            }
        }
    }
}