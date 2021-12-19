using FlappyClone.Core;
using TMPro;
using UnityEngine;

namespace FlappyClone.UI
{
    public class ScoreVisualizer : MonoBehaviour
    {
        [SerializeField] private Scorebook score;
        [SerializeField] private TextMeshProUGUI text;

        private void OnEnable()
        {
            score.OnScoreChanged += UpdateScore;
        }

        private void OnDisable()
        {
            score.OnScoreChanged -= UpdateScore;
        }

        private void UpdateScore(int newScore)
        {
            text.text = newScore.ToString();
        }
    }
}