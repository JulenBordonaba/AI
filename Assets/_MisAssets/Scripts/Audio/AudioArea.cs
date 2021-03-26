using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{

    [RequireComponent(typeof(Collider))]
    public class AudioArea : MonoBehaviour
    {
        public int checksPerSecond = 10;
        public float startTime = 0;

        public List<AudioElement> audioElements = new List<AudioElement>();

        private Collider effectArea;
        private bool checking = false;

        private void Awake()
        {
            effectArea = GetComponent<Collider>();
        }

        private void Start()
        {
            StartChecking();
        }
        

        public void CastAudio(SoundData sound)
        {
            foreach(AudioElement audioElement in audioElements)
            {
                audioElement.OnSoundRecieved?.Invoke(sound);
            }
        }

        #region Check Elements

        private void CheckElements()
        {

            for (int i = 0; i < AudioElement.activeAudioElements.Count; i++)
            {
                AudioElement audioElement = AudioElement.activeAudioElements[i];

                bool isInside = IsTransformInside(effectArea,audioElement.transform);

                CheckElement(audioElement, isInside);
                
            }
        }

        private void CheckElement(AudioElement audioElement, bool isInside)
        {
            if(isInside)
            {
                if(!audioElements.Contains(audioElement))
                {
                    audioElements.Add(audioElement);
                    audioElement.OnAudioAreaEnter(this);
                }
            }
            else
            {
                if(audioElements.Contains(audioElement))
                {
                    audioElements.Remove(audioElement);
                    audioElement.OnAudioAreaExit(this);
                }
            }
        }

        private bool IsTransformInside(Collider col, Transform trans)
        {
            if (effectArea.bounds.Contains(trans.position))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StartChecking()
        {
            checking = true;
            StartCoroutine(CheckRepeat());
        }

        public void StopChecking()
        {
            checking = false;
        }

        IEnumerator CheckRepeat()
        {
            yield return new WaitForSeconds(startTime);
            while(checking)
            {
                CheckElements();
                yield return new WaitForSeconds(CheckRepeatRate);
            }
        }

        private float CheckRepeatRate
        {
            get
            {
                return 1f / checksPerSecond;
            }
        }

        #endregion
    }
}
