using UnityEngine;
using UnityEngine.UI;

namespace ADH.Game
{
    [RequireComponent(typeof(Text))]
    public class ScoreText : MonoBehaviour
    {
        private ADHScoreSystem adhScoreSystem;

        private Text _scoreText;

        private void Awake()
        {
            adhScoreSystem = FindObjectOfType<ADHScoreSystem>();
            _scoreText = GetComponent<Text>();
        }

        private void Start()
        {
            _scoreText.text = ((int)adhScoreSystem.Score).ToString();
            adhScoreSystem.OnScoreChanged.AddListener(OnScoreChanged);
        }

        private void OnScoreChanged(float score, float amount)
        {
            _scoreText.text = ((int)score).ToString();
        }
    }
}