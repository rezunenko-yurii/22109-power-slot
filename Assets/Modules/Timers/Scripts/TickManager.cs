using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Installers;
using Modules.Coroutines.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Timers.Scripts
{
    public class TickManager : IPreInitializable
    {
        [Inject] private CoroutinesManager _coroutinesManager;
        private const float TimeStep = 1f;
        
        private List<Action> _actions;
        private List<Action> _queueToAdd;
        private List<Action> _queueToRemove;

        public void PreInitialize()
        {
            _actions = new List<Action>();
            _queueToAdd = new List<Action>();
            _queueToRemove = new List<Action>();
            
            _coroutinesManager.StartCoroutine(Tick());
        }
        
        private bool IsContainsAction(Action action) => _actions.Contains(action);
        
        public void Add(Action action)
        {
            if (IsContainsAction(action))
            {
                return;
            }
            else
            {
                _queueToAdd.Add(action);
            }
        }
        
        public void Remove(Action action)
        {
            if (IsContainsAction(action))
            {
                _queueToRemove.Add(action);
            }
            else
            {
                return;
            }
        }
        
        private IEnumerator Tick()
        {
            while (true)
            {
                yield return new WaitForSeconds(TimeStep);
                
                foreach (var action in _actions)
                {
                    action?.Invoke();
                }

                if (_queueToAdd.Count > 0)
                {
                    _actions = _actions.Concat(_queueToAdd).ToList();
                    _queueToAdd.Clear();
                }

                if (_queueToRemove.Count > 0)
                {
                    _actions = _actions.Except(_queueToRemove).ToList();
                    _queueToRemove.Clear();
                }
            }
        }
    }
}