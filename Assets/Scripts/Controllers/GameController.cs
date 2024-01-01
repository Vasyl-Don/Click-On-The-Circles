using System.Collections.Generic;
using System.Linq;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        private List<IGameController> _controllers;
        
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
            _controllers = FindObjectsOfType<MonoBehaviour>().OfType<IGameController>().ToList();
            foreach (var controller in _controllers)
            {
                controller.OnAwake();
            }
        }
        
        private void StartPlaying()
        {
            foreach (var controller in _controllers)
            {
                controller.OnStartPlaying();
            }
        }
        
        private void FinishPlaying()
        {
            foreach (var controller in _controllers)
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