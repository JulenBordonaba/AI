using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{
    public abstract class AudioElement : MonoBehaviour
    {
        public static List<AudioElement> activeAudioElements = new List<AudioElement>();

        public delegate void RecieveSound(SoundData sound);

        public RecieveSound OnSoundRecieved;

        protected void OnEnable()
        {
            AddToActiveElements();
        }

        protected void OnDisable()
        {
            RemoveFromActiveElements();
        }

        protected void AddToActiveElements()
        {
            if (!activeAudioElements.Contains(this))
            {
                activeAudioElements.Add(this);
            }
        }

        protected void RemoveFromActiveElements()
        {
            if (activeAudioElements.Contains(this))
            {
                activeAudioElements.Remove(this);
            }
        }

        public abstract void OnAudioAreaEnter(AudioArea src);

        public abstract void OnAudioAreaExit(AudioArea src);
        
    }
}


