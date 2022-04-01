using System;
using UnityEngine;

namespace Core.Audio
{
    [Serializable]
    public class Sound
    {
        public SoundName name;
        public AudioClip clip;
    }
}