using System.Collections;
using Entities;
using Interfaces;
using ScriptableObjects;
using Services;
using UnityEngine;

namespace EventProcessors
{
    public class GameplayEventProcessor : MonoBehaviour, IGameEventProcessor
    {
        private int _secondsLeft;

        private ProgressScriptableObject _progress;
        private GameManagerScriptableObject _gameManager;

        private const string ProgressScriptableObjectPath = "Scriptables/Progress Info";
        private const string GameManagerScriptableObjectPath = "Scriptables/Game Manager";

        private const float SpawningWaitTime = 0.5f;

        public void OnAwake()
        {
            _progress = Resources.Load<ProgressScriptableObject>(ProgressScriptableObjectPath);
            _gameManager = Resources.Load<GameManagerScriptableObject>(GameManagerScriptableObjectPath);
        }

        public void OnStartPlaying()
        {
            _progress.ResetScore();
            _progress.ResetSecondsLeft();
            StartCoroutine(TimerCoroutine());
            StartCoroutine(SpawningBubblesCoroutine());
        }

        public void OnGameOver()
        {
            StopCoroutine(TimerCoroutine());
            StopCoroutine(SpawningBubblesCoroutine());
            
            var bubbles = FindObjectsOfType<Bubble>();
            foreach (var bubble in bubbles)
            {
                bubble.PopBubble(false);
            }

            _progress.EndGame();
        }

        private IEnumerator TimerCoroutine()
        {
            _secondsLeft = _progress.SecondsLimit;
            while (_secondsLeft > 0)
            {
                yield return new WaitForSeconds(1f);
                _secondsLeft--;
                _progress.UpdateSecondsLeft();
            }

            _gameManager.FinishPlaying();
        }

        private IEnumerator SpawningBubblesCoroutine()
        {
            var bubbleSpawner = new BubbleSpawner();
            while (_secondsLeft > 0)
            {
                bubbleSpawner.SpawnRandomBubble();
                yield return new WaitForSeconds(SpawningWaitTime);
            }
        }
    }
}