using System;
using Enums;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Game Manager", menuName = "ScriptableObjects/Game Manager")]
    public class GameManagerScriptableObject : ScriptableObject
    {
        private GameState _gameState;
        
        [NonSerialized] public UnityEvent GameStarted;
        [NonSerialized] public UnityEvent GameOver;
        
        private void OnEnable()
        {
            _gameState = GameState.Start;
            
            GameStarted ??= new UnityEvent();
            GameOver ??= new UnityEvent();
        }
        
        public void StartPlaying()
        {
            if (_gameState == GameState.Playing)
                return;
            _gameState = GameState.Playing;
            GameStarted?.Invoke();
        }
        
        public void FinishPlaying()
        {
            if (_gameState != GameState.Playing)
                return;
            _gameState = GameState.GameOver;
            GameOver?.Invoke();
        }
    }
}