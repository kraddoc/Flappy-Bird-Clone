using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Obstacles
{
    public class StopPipesOnDeath : DeathEventSubscriber
    {
        [SerializeField] private PipeSpawner spawner;

        protected override void Stop()
        {
            spawner.enabled = false;
            foreach (var o in FindObjectsOfType(typeof(PipeHorizontalMovement)))
            {
                var pipe = (PipeHorizontalMovement) o;
                pipe.enabled = false;
            }
        }
    }
}