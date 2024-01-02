using Interfaces;
using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace EventProcessors
{
    public class UIEventProcessor : MonoBehaviour, IGameEventProcessor
    {
        private GameObject _startCanvas;
        private GameObject _gameCanvas;
        private GameObject _gameOverCanvas;

        private TMP_Text _scoreText;
        private TMP_Text _timerText;

        private TMP_Text _gameOverScoreText;
        private TMP_Text _highScoreText;

        private ProgressScriptableObject _progress;
        private const string ProgressScriptableObjectPath = "Scriptables/Progress Info";
        
        private void OnEnable()
        {
            _progress = Resources.Load<ProgressScriptableObject>(ProgressScriptableObjectPath);
            _progress.SecondsLeftChanged.AddListener(UpdateTimerText);
            _progress.ScoreChanged.AddListener(UpdateScoreText);
            _progress.GameEnded.AddListener(UpdateResultsText);
        }

        public void OnAwake()
        {
            _startCanvas = gameObject.transform.Find("Start Canvas").gameObject;
            _gameCanvas = gameObject.transform.Find("Game Canvas").gameObject;
            _gameOverCanvas = gameObject.transform.Find("Game Over Canvas").gameObject;

            _timerText = _gameCanvas.transform.Find("Timer Text").GetComponent<TMP_Text>();
            _scoreText = _gameCanvas.transform.Find("Score Text").GetComponent<TMP_Text>();

            _gameOverScoreText = _gameOverCanvas.transform.Find("Score Text").GetComponent<TMP_Text>();
            _highScoreText = _gameOverCanvas.transform.Find("High Score Text").GetComponent<TMP_Text>();

            _startCanvas.SetActive(true);
            _gameCanvas.SetActive(false);
            _gameOverCanvas.SetActive(false);
        }

        public void OnStartPlaying()
        {
            _startCanvas.SetActive(false);
            _gameOverCanvas.SetActive(false);
            _gameCanvas.SetActive(true);
            UpdateTimerText();
        }

        public void OnGameOver()
        {
            _gameCanvas.SetActive(false);
            _gameOverCanvas.SetActive(true);
        }

        private void UpdateScoreText(int score)
        {
            _scoreText.text = $"score\n{score}";
        }
        
        private void UpdateResultsText(int finalScore, int highScore)
        {
            _gameOverScoreText.text = $"score\n{finalScore}";
            _highScoreText.text = $"high score\n{highScore}";
        }

        private void UpdateTimerText()
        {
            var minutes = _progress.SecondsLeft / 60;
            var seconds = _progress.SecondsLeft % 60;
            _timerText.text = $"{minutes}:{seconds:00}";
        }

        private void OnDisable()
        {
            _progress.SecondsLeftChanged.RemoveListener(UpdateTimerText);
            _progress.ScoreChanged.RemoveListener(UpdateScoreText);
            _progress.GameEnded.RemoveListener(UpdateResultsText);
        }
    }
}