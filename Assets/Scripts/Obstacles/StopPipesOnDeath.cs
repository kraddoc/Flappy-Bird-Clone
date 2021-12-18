using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Obstacles
{
    public class StopPipesOnDeath : StopScriptOnDeath
    {
        [SerializeField] private PipeSpawner pipeSpawner;

        protected override void Stop()
        {
            pipeSpawner.enabled = false;
            foreach (var o in FindObjectsOfType(typeof(PipeHorizontalMovement), true))
            {
                var pipe = (PipeHorizontalMovement) o;
                pipe.enabled = false;
            }
        }
    }
}