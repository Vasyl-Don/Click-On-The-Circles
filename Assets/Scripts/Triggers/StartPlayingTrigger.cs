using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Triggers
{
    [RequireComponent(typeof(Button))]
    public class StartPlayingTrigger : MonoBehaviour
    {
        [SerializeField] private GameManagerScriptableObject _gameManager;
        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(StartPlaying);
        }
        
        private void StartPlaying()
        {
            _gameManager.StartPlaying();
        }
    }
}