using System;
using UnityEngine;

namespace FlappyClone.Environment
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PipesZone : MonoBehaviour
    {
        // Dummy script for pipe detection specifically.
        // Used for returning pipes back to object pool and for score increase.

        private void Start()
        {
            TryGetComponent(out BoxCollider2D box);
            box.isTrigger = true; //making sure it's trigger.
        }
    }
}