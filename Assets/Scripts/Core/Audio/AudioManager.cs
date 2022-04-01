using UnityEngine;

namespace Core.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private MusicController _musicController;
        private void Awake()
        {
            var audioManagers = FindObjectsOfType<AudioManager>();

            if (audioManagers.Length > 1)
            {
                Destroy(this.gameObject);
            }
        }

        public void SetMusicVolume(float value)
        {
        
        }
    
        public void SetSoundsVolume(float value)
        {
        
        }
    }
}
