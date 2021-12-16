using System;
using UnityEngine;

namespace FlappyClone.Environment
{
    [RequireComponent(typeof(Collider2D))]
    public class Obstacle : MonoBehaviour
    {
        // Dummy script for collision detection.
        // When the bird touches a game object with a collider and this component, it's game over.
        // I find using tags for this purpose to be unreliable from dev standpoint, so I use components, even if they don't contain any logic.
        // Plus, autocomplete doesn't recognize tags, but works fine with component names.
        // It also makes sure the object has actual collider attached.
    }
}
