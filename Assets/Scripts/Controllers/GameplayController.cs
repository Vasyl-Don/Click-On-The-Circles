using System.Collections;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Controllers
{
    public class GameplayController : MonoBehaviour, IGameController
    {
        private int _secondsLeft;
        
        [SerializeField] private ProgressScriptableObject _progress;
        [SerializeField] private GameManagerScriptableObject _gameManager;
        
        public void OnStart()
        {
            
        }

        public void OnStartPlaying()
        {
            _progress.ResetScore();
            _progress.ResetSecondsLeft();
            StartCoroutine(SpawningCirclesCoroutine());
        }
    
        public void OnUpdate()
        {
            
        }

        public void OnGameOver()
        {
            StopCoroutine(SpawningCirclesCoroutine());
            _progress.EndGame();
        }

        private IEnumerator SpawningCirclesCoroutine()
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
    }
}
