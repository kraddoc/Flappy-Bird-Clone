using System.Collections.Generic;
using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Obstacles
{
    public class PausePipes : PauseEventSubscriber
    {
        [SerializeField] private PipeSpawner spawner;
        private List<PipeHorizontalMovement> _pausedPipes = new();
        
        // There's duplicate code with another class, but I think it's clean enough.
        protected override void Pause()
        {
            spawner.enabled = false;
            foreach (var o in FindObjectsOfType(typeof(PipeHorizontalMovement)))
            {
                var pipe = (PipeHorizontalMovement) o;
                pipe.enabled = false;
                _pausedPipes.Add(pipe);
            }
        }

        protected override void Unpause()
        {
            spawner.enabled = true;
            foreach (var pipe in _pausedPipes)
            {
                pipe.enabled = true;
            }
            _pausedPipes.Clear();
        }
    }
}