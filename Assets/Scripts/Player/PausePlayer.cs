using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.Player
{
    public class PausePlayer : PauseEventSubscriber
    {
        [SerializeField] private Flight flight;
        [SerializeField] private FaceTowardsVelocity rotator;
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Animator animator;

        private Vector2 _savedVelocity;

        protected override void Pause()
        {
            _savedVelocity = rb2d.velocity;
            rb2d.bodyType = RigidbodyType2D.Static;
            flight.enabled = false;
            rotator.enabled = false;
            animator.enabled = false;
        }

        protected override void Unpause()
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.velocity = _savedVelocity;
            flight.enabled = true;
            rotator.enabled = true;
            animator.enabled = true;
        }
    }
}