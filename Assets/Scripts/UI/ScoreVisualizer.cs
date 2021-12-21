using FlappyClone.Core;
using TMPro;
using UnityEngine;

namespace FlappyClone.UI
{
    public class ScoreVisualizer : MonoBehaviour
    {
        [SerializeField] private Scorebook score;
        [SerializeField] private TextMeshProUGUI currentScore;
        [SerializeField] private TextMeshProUGUI maxScore;

        private void OnEnable()
        {
            score.OnScoreChanged += UpdateScore;
            score.OnNewRecord += UpdateRecord;
        }

        private void OnDisable()
        {
            score.OnScoreChanged -= UpdateScore;
            score.OnNewRecord -= UpdateRecord;
        }

        private void UpdateScore(int newScore)
        {
            currentScore.text = newScore.ToString();
        }

        private void UpdateRecord(int newRecord)
        {
            maxScore.text = $"RECORD - {newRecord}";
        }
    }
}