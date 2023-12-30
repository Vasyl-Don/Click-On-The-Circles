using System;
using Enums;
using Interfaces;
using UnityEngine;

namespace Controllers
{
    public class GameManager : MonoBehaviour, IGameController
    {
        private GameState _gameState;

        public void OnStartPlaying()
        {
            throw new NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public void OnGameOver()
        {
            throw new NotImplementedException();
        }
    }
}