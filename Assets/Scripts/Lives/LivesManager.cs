using System;
using Core.Collectables;
using Modules.Timers.Scripts;
using UnityEngine;

namespace Lives
{
    public class LivesManager
    {
        public MemoryTimer Timer { get; private set; }
        private int _cooldown;
        private int _maxLives;
        private IntCollectableObject _activeLives;
        
        public void Init(int maxLives, int cooldown, MemoryTimer timer)
        {
            _maxLives = maxLives;
            _cooldown = cooldown;

            _activeLives = new IntCollectableObject("Lives", _maxLives);
            
            Timer = timer;
            Timer.Over += OnCooldown;
            
            if (Timer.IsExpired && _activeLives.Amount < 3)
            {
                var timeSpan = DateTimeOffset.Now - Timer.Keeper.Date;
                int newLivesAmount = (int) timeSpan.TotalHours / 3;
                TryAddLive(newLivesAmount);
            }
        }

        private void OnCooldown()
        {
            TryAddLive();
            TryStartCooldown();
        }

        private void TryStartCooldown()
        {
            if (!IsMaxActiveLives)
            {
                Debug.Log($"{nameof(LivesManager)} timer is started");
                Timer.Keeper.AddHours(_cooldown);
            }
        }

        public void TryAddLive(int amount = 1)
        {
            var newAmount =Mathf.Clamp(_activeLives.Amount + amount, 0, _maxLives);
            _activeLives.Amount = newAmount;
        }

        private bool IsMaxActiveLives => _activeLives.Amount == _maxLives;
        public int ActiveLivesAmount => _activeLives.Amount;

        public void TryTakeLive()
        {
            if (_activeLives.Amount > 0)
            {
                TakeLive();
            }
            else
            {
                Debug.Log($"{nameof(LivesManager)} can`t take life, its already zero");
            }
        }

        private void TakeLive()
        {
            _activeLives.Decrease();
            if (Timer.IsExpired)
            {
                Timer.Keeper.AddMinutesFromNow(_cooldown);
            }
            
            Debug.Log($"{nameof(LivesManager)} Live is taken, left {_activeLives.Amount}");
        }
    }
}