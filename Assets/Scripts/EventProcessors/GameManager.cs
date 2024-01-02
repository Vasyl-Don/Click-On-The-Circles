using System.Collections.Generic;
using System.Linq;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace EventProcessors
{
    public class GameManager : MonoBehaviour
    {
        private List<IGameEventProcessor> _eventProcessors;
        
        private GameManagerScriptableObject _gameManager;
        private const string GameManagerScriptableObjectPath = "Scriptables/Game Manager";
        
        private void OnEnable()
        {
            _gameManager = Resources.Load<GameManagerScriptableObject>(GameManagerScriptableObjectPath);
            _gameManager.GameStarted.AddListener(StartPlaying);
            _gameManager.GameOver.AddListener(FinishPlaying);
        }

        private void Awake()
        {
            _eventProcessors = FindObjectsOfType<MonoBehaviour>().OfType<IGameEventProcessor>().ToList();
            foreach (var controller in _eventProcessors)
            {
                controller.OnAwake();
            }
        }
        
        private void StartPlaying()
        {
            foreach (var controller in _eventProcessors)
            {
                controller.OnStartPlaying();
            }
        }
        
        private void FinishPlaying()
        {
            foreach (var controller in _eventProcessors)
            {
                controller.OnGameOver();
            }
        }
        
        private void OnDisable()
        {
            _gameManager.GameStarted.RemoveListener(StartPlaying);
            _gameManager.GameOver.RemoveListener(FinishPlaying);
        }
    }
}