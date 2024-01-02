using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Progress Info", menuName = "ScriptableObjects/Progress")]
    public class ProgressScriptableObject : ScriptableObject
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }

        [SerializeField] private int _secondsLimit;
        public int SecondsLimit => _secondsLimit;
        public int SecondsLeft { get; private set; }

        [NonSerialized] public UnityEvent<int> ScoreChanged;
        [NonSerialized] public UnityEvent<int, int> GameEnded;
        [NonSerialized] public UnityEvent SecondsLeftChanged;

        private void OnEnable()
        {
            Score = 0;
            HighScore = PlayerPrefs.GetInt("HighScore", 0);
            SecondsLeft = _secondsLimit;

            ScoreChanged ??= new UnityEvent<int>();
            GameEnded ??= new UnityEvent<int, int>();
            SecondsLeftChanged ??= new UnityEvent();
        }

        public void UpdateSecondsLeft()
        {
            SecondsLeft--;
            SecondsLeftChanged?.Invoke();
        }

        public void UpdateScore(int points)
        {
            Score += points;
            ScoreChanged?.Invoke(Score);
        }

        public void EndGame()
        {
            if (Score > HighScore)
            {
                HighScore = Score;
                PlayerPrefs.SetInt("HighScore", Score);
                PlayerPrefs.Save();
            }
            GameEnded?.Invoke(Score, HighScore);
        }

        public void ResetScore()
        {
            Score = 0;
            ScoreChanged?.Invoke(Score);
        }

        public void ResetSecondsLeft()
        {
            SecondsLeft = SecondsLimit;
            SecondsLeftChanged?.Invoke();
        }
    }
}