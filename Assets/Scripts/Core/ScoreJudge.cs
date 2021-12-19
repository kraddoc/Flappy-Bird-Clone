using System;
using FlappyClone.Player;
using UnityEngine;

namespace FlappyClone.Core
{
    public class ScoreJudge : MonoBehaviour
    {
        public event Action<int> OnScoreChanged;
        public event Action<int> OnNewRecord;
        
        [SerializeField] private Scorer scorer;
        [SerializeField] private DeathToggle deathToggle;
        private int _score;
        private int _record;

        private void OnEnable()
        {
            scorer.OnScored += IncreaseScore;
            deathToggle.OnDeath += CheckIfNewRecord;
        }

        private void OnDisable()
        {
            scorer.OnScored -= IncreaseScore;
            deathToggle.OnDeath -= CheckIfNewRecord;
        }

        private void IncreaseScore()
        {
            _score++;
            OnScoreChanged?.Invoke(_score);
        }

        private void CheckIfNewRecord()
        {
            if (_score > _record)
            {
                _record = _score;
                OnNewRecord?.Invoke(_record);
            }
        }
    }
}
