using System;
using UnityEngine;

namespace ADH.Game
{
    public class ADHScoreSystem : MonoBehaviour, IScoreSystem
    {
        private const string PlayerPrefsKey = "Score";

        private float _score;

        private ScoreChangedEvent onScoreChanged = new ScoreChangedEvent();

        public float Score => _score;

        public ScoreChangedEvent OnScoreChanged => onScoreChanged;

        private void Awake()
        {
            ADHLoadScore();
            return;
            void ADHLoadScore()
            {
                if (PlayerPrefs.HasKey(PlayerPrefsKey))
                {
                    _score = PlayerPrefs.GetFloat(PlayerPrefsKey);
                }
            }
        }

        public void ModifyScore(float amount)
        {
            _score += amount;

            OnScoreChanged.Invoke(_score, amount);
        }

        public void ResetScore()
        {
            _score = 0;
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat(PlayerPrefsKey, _score);

        }
    }
}