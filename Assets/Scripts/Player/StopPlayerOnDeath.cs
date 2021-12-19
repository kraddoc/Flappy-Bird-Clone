using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Player
{
    public class StopPlayerOnDeath : DeathEventSubscriber
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Flight flight;
        
        protected override void Stop()
        {
            animator.enabled = false;
            flight.enabled = false;
        }
    }
}