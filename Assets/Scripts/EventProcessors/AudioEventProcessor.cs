using Enums;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace EventProcessors
{
    public class AudioEventProcessor : MonoBehaviour, IGameEventProcessor
    {
        private SoundsContainer _soundsContainer;
        private const string SoundsContainerPath = "Scriptables/Sounds";
        
        public void OnAwake()
        {
            _soundsContainer = Resources.Load<SoundsContainer>(SoundsContainerPath);
        }

        public void OnStartPlaying()
        {
            PlaySound(SoundType.Start);
        }

        public void OnGameOver()
        {
            PlaySound(SoundType.GameOver);
        }
        
        public void PlaySound(SoundType soundType)
        {
            var clip = _soundsContainer.GetAudioClip(soundType);
            if (clip != null)
            {
                AudioSource.PlayClipAtPoint(clip, Vector3.zero);
            }
        }
    }
}