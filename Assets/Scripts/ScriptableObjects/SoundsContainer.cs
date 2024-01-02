using System.Collections.Generic;
using System.Linq;
using Entities;
using Enums;
using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Sounds Container", fileName = "Sounds")]
    public class SoundsContainer : ScriptableObject
    {
        public List<SoundModel> Sounds;

        public AudioClip GetAudioClip(SoundType soundType)
        {
            var clip = Sounds.FirstOrDefault(snd => snd.SoundType == soundType)?.AudioClip;
            if (clip == null) 
                Debug.LogError($"Not found sound of type {soundType} in Sounds Container");
            return clip;
        }
    }
}