using Interfaces;
using UnityEngine;

namespace Controllers
{
    public class UIController : MonoBehaviour, IGameController
    {
        private GameObject _startCanvas;
        private GameObject _gameCanvas;
        private GameObject _gameOverCanvas;

        public void OnStartPlaying()
        {
            _startCanvas = GameObject.Find("Start Canvas");
            _gameCanvas = GameObject.Find("Game Canvas");
            _gameOverCanvas = GameObject.Find("Game Over Canvas");
        
            _startCanvas.SetActive(true);
            _gameCanvas.SetActive(false);
            _gameOverCanvas.SetActive(false);
        }

        public void OnUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnGameOver()
        {
            throw new System.NotImplementedException();
        }
    }
}
