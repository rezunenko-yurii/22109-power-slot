using System;
using System.Collections;
using System.Collections.Generic;
using Installers;
using Modules.Coroutines.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Timers.Scripts
{
    public class TickManager : IPreInitializable
    {
        [Inject] private CoroutinesManager _coroutinesManager;
        private const float TimeStep = 0.01f;
        private List<Action> _actions = new List<Action>();

        public void PreInitialize()
        {
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
                _actions.Add(action);
            }
        }
        
        public void Remove(Action action)
        {
            if (IsContainsAction(action))
            {
                _actions.Add(action);
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
            }
        }
    }
}