using System;
using FlappyClone.Player;
using UnityEngine;

namespace FlappyClone.Core
{
    public class Scorebook : MonoBehaviour
    {
        public event Action<int> OnScoreChanged;
        public event Action<int> OnNewRecord;
        
        [SerializeField] private Scorer scorer;
        [SerializeField] private DeathObserver deathObserver;
        private int _score;
        private int _record;
        private bool _counting = true;

        private void OnEnable()
        {
            scorer.OnScored += IncreaseScore;
            deathObserver.OnDeath += CheckIfNewRecord;
        }

        private void OnDisable()
        {
            scorer.OnScored -= IncreaseScore;
            deathObserver.OnDeath -= CheckIfNewRecord;
        }

        private void IncreaseScore()
        {
            if (!_counting) return;
            _score++;
            OnScoreChanged?.Invoke(_score);
        }

        private void CheckIfNewRecord()
        {
            if (_score > _record)
            {
                _record = _score;
                PlayerPrefs.SetInt("highScore", _record); 
                OnNewRecord?.Invoke(_record);
            }
        }

        private void StopCount()
        {
            _counting = false;
        }
    }
}
