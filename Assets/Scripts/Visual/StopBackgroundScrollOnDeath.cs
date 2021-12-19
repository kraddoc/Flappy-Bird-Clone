using FlappyClone.Core;

namespace FlappyClone.Visual
{
    public class StopBackgroundScrollOnDeath : DeathEventSubscriber
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