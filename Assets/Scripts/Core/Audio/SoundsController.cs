using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.Audio
{
    public class SoundsController : AudioController
    {
        //private AudioSource _audioSource;
        [Inject] private SoundsCollection _soundsCollection;
        protected override string ControllerName { get; } = "SoundsController";
        
        private Stack<AudioSource> _cachedAudioSources = new Stack<AudioSource>();
        private List<AudioSource> _playingAudioSources = new List<AudioSource>();

        private List<Coroutine> _activeCoroutines = new List<Coroutine>();

        public void Play(SoundName soundName)
        {
            var sound = _soundsCollection[soundName];
            
            var source = ValidateAudioSource();
            
            source.clip = sound;
            _playingAudioSources.Add(source);
            source.Play();
            
            var coroutineBox = new CoroutineBox();
            IEnumerator myCoroutine =  WaitAudio(coroutineBox, source);
            coroutineBox.coroutine = StartCoroutine(myCoroutine);
            _activeCoroutines.Add(coroutineBox.coroutine);
        }
        
        public void Play(AudioClip clip)
        {
            var source = ValidateAudioSource();
            
            source.clip = clip;
            _playingAudioSources.Add(source);
            source.Play();
            
            var coroutineBox = new CoroutineBox();
            IEnumerator myCoroutine =  WaitAudio(coroutineBox, source);
            coroutineBox.coroutine = StartCoroutine(myCoroutine);
            _activeCoroutines.Add(coroutineBox.coroutine);
        }
        
        public AudioSource PlayLooped(AudioClip clip)
        {
            var source = ValidateAudioSource();
            
            source.clip = clip;
            _playingAudioSources.Add(source);
            source.loop = true;
            source.Play();

            return source;
        }

        public void StopLooped(AudioSource source)
        {
            if (_playingAudioSources.Contains(source))
            {
                source.loop = false;
                source.Stop();
                source.clip = null;
                
                ReturnSourceToCached(source);
            }
        }
        
        private IEnumerator WaitAudio(CoroutineBox box,AudioSource source)
        {
            yield return new WaitForSeconds(source.clip.length);
            
            _activeCoroutines.Remove(box.coroutine);
            ReturnSourceToCached(source);
        }

        private void ReturnSourceToCached(AudioSource source)
        {
            _playingAudioSources.Remove(source);
            _cachedAudioSources.Push(source);
        }

        private AudioSource ValidateAudioSource()
        {
            var source = _cachedAudioSources.Count > 0 ? _cachedAudioSources.Pop() : gameObject.AddComponent<AudioSource>();
            source.volume = Volume;
            return source;
        }

        protected override void OnVolumeChanged()
        {
            base.OnVolumeChanged();

            foreach (var source in _playingAudioSources)
            {
                source.volume = Volume;
            }
        }

        private void OnDestroy()
        {
            foreach (var coroutine in _activeCoroutines)
            {
                StopCoroutine(coroutine);
            }
            
            _activeCoroutines.Clear();
        }
    }
}