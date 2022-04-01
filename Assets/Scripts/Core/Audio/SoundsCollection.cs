using System.Collections.Generic;
using UnityEngine;

namespace Core.Audio
{
    [CreateAssetMenu(fileName = "Sounds", menuName = "Audio/Create Sounds Collection")]
    public class SoundsCollection : ScriptableObject
    {
        [SerializeField] private List<Sound> sounds = new List<Sound>();
        public AudioClip this[SoundName soundName] => sounds.Find(x => x.name.Equals(soundName)).clip;
    }
}
