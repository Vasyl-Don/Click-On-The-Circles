using System.Collections;
using Entities;
using Interfaces;
using ScriptableObjects;
using Services;
using UnityEngine;

namespace Controllers
{
    public class GameplayController : MonoBehaviour, IGameController
    {
        private int _secondsLeft;
        
        [SerializeField] private ProgressScriptableObject _progress;
        [SerializeField] private GameManagerScriptableObject _gameManager;
        
        private const float SpawningWaitTime = 0.5f;
        
        public void OnStart()
        {
            
        }

        public void OnStartPlaying()
        {
            _progress.ResetScore();
            _progress.ResetSecondsLeft();
            StartCoroutine(TimerCoroutine());
            StartCoroutine(SpawningBubblesCoroutine());
        }
    
        public void OnUpdate()
        {
            
        }

        public void OnGameOver()
        {
            StopCoroutine(TimerCoroutine());
            StopCoroutine(SpawningBubblesCoroutine());
            var bubbles = FindObjectsOfType<Bubble>();
            foreach (var bubble in bubbles)
            {
                bubble.PopBubble();
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
