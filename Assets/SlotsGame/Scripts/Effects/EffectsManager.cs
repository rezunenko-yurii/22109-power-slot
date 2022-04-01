using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace SlotsGame.Scripts.Effects
{
    public class EffectsManager : MonoBehaviour
    {
        public Action Completed;
        
        [SerializeField] private PlayableDirector freespins;
        private Queue<EffectsTypes> _query = new Queue<EffectsTypes>();

        public void Play()
        {
            Debug.Log($"{nameof(EffectsManager)} {nameof(Play)}");
            
            if (_query.Count > 0)
            {
                var effectsTypes = _query.Dequeue();
                PlayEffect(effectsTypes);
            }
            else
            {
                Debug.Log($"{nameof(EffectsManager)} {nameof(Play)} All Animations Played");
                Completed?.Invoke();
            }
        }

        private void PlayEffect(EffectsTypes effectsTypes)
        {
            if (effectsTypes == EffectsTypes.FreeSpins)
            {
                Debug.Log($"{nameof(EffectsManager)} {nameof(PlayEffect)} FreeSpins " +
                          $"duration={freespins.duration}" +
                          $"time={freespins.time}" +
                          $"state={freespins.state}" +
                          $"initTime={freespins.initialTime}");
                
                freespins.stopped += OnPlayed;
                freespins.Play();
            }
            else
            {
                Play();
            }
        }

        private void OnPlayed(PlayableDirector obj)
        {
            Debug.Log($"{nameof(EffectsManager)} {obj.name} {nameof(OnPlayed)}");
            
            obj.stopped -= OnPlayed;
            Play();
        }

        public void AddToQuery(EffectsTypes freeSpins)
        {
            _query.Enqueue(freeSpins);
        }
    }
}
