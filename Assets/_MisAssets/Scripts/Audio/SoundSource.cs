using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{

    public class SoundSource : AudioElement
    {
        public List<AudioArea> audioAreas = new List<AudioArea>();
        public override void OnAudioAreaEnter(AudioArea src)
        {
            audioAreas.Add(src);
        }

        public override void OnAudioAreaExit(AudioArea src)
        {
            audioAreas.Remove(src);
        }

        public void CastAudio(SoundData sound)
        {
            foreach(AudioArea audioArea in audioAreas)
            {
                audioArea.CastAudio(sound);
            }
        }
    }

}
