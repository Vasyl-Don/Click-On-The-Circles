using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Triggers
{
    [RequireComponent(typeof(Button))]
    public class StartPlayingTrigger : MonoBehaviour
    {
        private GameManagerScriptableObject _gameManager;
        private const string GameManagerScriptableObjectPath = "Scriptables/Game Manager";
        
        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(StartPlaying);
        }
        
        private void Awake()
        {
            _gameManager = Resources.Load<GameManagerScriptableObject>(GameManagerScriptableObjectPath);
        }
        
        private void StartPlaying()
        {
            _gameManager.StartPlaying();
        }
        
        private void OnDisable()
        {
            GetComponent<Button>().onClick.RemoveListener(StartPlaying);
        }
    }
}