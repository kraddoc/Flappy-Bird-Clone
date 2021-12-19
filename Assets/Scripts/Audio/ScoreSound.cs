using FlappyClone.Player;
using UnityEngine;

namespace FlappyClone.Audio
{
    public class ScoreSound : PlaySound
    {
        [SerializeField] private Scorer scorer;

        private void OnEnable()
        {
            scorer.OnScored += Play;
        }

        private void OnDisable()
        {
            scorer.OnScored -= Play;
        }
    }
}