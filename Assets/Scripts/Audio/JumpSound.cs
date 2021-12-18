using FlappyClone.Player;
using UnityEngine;

namespace FlappyClone.Audio
{
    public class JumpSound : PlaySound
    {
        [SerializeField] private Flight flight;

        private void OnEnable()
        {
            flight.OnJump += Play;
        }

        private void OnDisable()
        {
            flight.OnJump -= Play;
        }
    }
}