using System.Collections.Generic;
using System.Linq;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Controllers
{
    public class GameManager : MonoBehaviour
    {
        private List<IGameController> _controllers;
        
        [SerializeField] private GameManagerScriptableObject _gameManager;

        private void OnEnable()
        {
            _gameManager.GameStarted.AddListener(StartPlaying);
            _gameManager.GameOver.AddListener(FinishPlaying);
        }

        private void Start()
        {
            _controllers = FindObjectsOfType<MonoBehaviour>().OfType<IGameController>().ToList();
            foreach (var controller in _controllers)
            {
                controller.OnStart();
            }
        }
        
        private void StartPlaying()
        {
            foreach (var controller in _controllers)
            {
                controller.OnStartPlaying();
            }
        }
        
        private void Update()
        {
            foreach (var controller in _controllers)
            {
                controller.OnUpdate();
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