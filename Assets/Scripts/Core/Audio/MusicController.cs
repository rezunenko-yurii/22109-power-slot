using UnityEngine;

namespace Core.Audio
{
    public class MusicController : AudioController
    {
        private AudioSource _audioSource;
        protected override string ControllerName { get; } = "MusicController";

        protected override void Awake()
        {
            base.Awake();
        
            Debug.Log($"{nameof(MusicController)} {nameof(Awake)} / Volume={Volume}");
        
            _audioSource = gameObject.AddComponent(typeof(AudioSource)).GetComponent<AudioSource>();
            _audioSource.volume = Volume;
        }

        public void Play(AudioClip audioClip)
        {
            _audioSource.clip = audioClip;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    
        public void Play()
        {
            _audioSource.Play();
        }

        public void Pause()
        {
            _audioSource.Pause();
        }

        public void Stop()
        {
            _audioSource.Stop();
        }
    
        protected override void OnVolumeChanged()
        {
            base.OnVolumeChanged();

            _audioSource.volume = Volume;
        }
    }
}