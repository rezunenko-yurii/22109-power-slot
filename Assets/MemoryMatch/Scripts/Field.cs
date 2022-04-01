using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using GameCores.MemoryMatchGame;
using TMPro;
using UnityEngine;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class Field : AdvancedMonoBehaviour
    {
        public event Action Won;
        public event Action Lose;

        [Inject] private SignalBus _signalBus;
        
        [SerializeField] private FieldBuilder _builder;
        [SerializeField] private TextMeshProUGUI _attemptsLeftText;
        
        [SerializeField] private FieldAnimator _animator;
        private ProgressWatcher _progressWatcher;
        
        private List<Element> _elements;
        private LevelsManager _levelsManager;
        
        private List<Element> _selectedElements;
        private Coroutine _coroutine;
        
        public void Init(LevelsManager current)
        {
            _selectedElements = new List<Element>();
            _levelsManager = current;
            
            _progressWatcher = new ProgressWatcher();
            _progressWatcher.Won += OnWon;
            _progressWatcher.Lose += OnLose;
            _progressWatcher.Continue += OnContinue;
            _progressWatcher.Match += OnMatch;
            _progressWatcher.Dissmatch += OnDissmatch;
            
        }
        
        public void StartGame()
        {
            _progressWatcher.Init(_levelsManager.Current);
            _elements = _builder.Build(_levelsManager.Current);
            
            ChangeAttemptsLeftText();
            SubscribeForClick();
            ShowAll();
        }

        private void ChangeAttemptsLeftText()
        {
            _attemptsLeftText.text = _progressWatcher.AttemptsLeft.ToString();
        }

        private void OnMatch()
        {
            ClearSelected();
            ResumeInput();
        }
        
        private void OnDissmatch()
        {
            PauseInput();
            _coroutine = StartCoroutine(Pause(1, AnimateDissmatched));
        }

        private void AnimateDissmatched()
        {
            _animator.TryPlay(_selectedElements, OnDissmatchAnimated);
        }
        
        private void OnDissmatchAnimated()
        {
            ClearSelected();
            ChangeAttemptsLeftText();
            ResumeInput();
        }

        private void ClearSelected()
        {
            _selectedElements.Clear();
        }

        private void ClearAll()
        {
            _elements?.Clear();
        }

        private void OnLose()
        {
            Debug.Log("Lose");
            ChangeAttemptsLeftText();
            Lose?.Invoke();
        }
        
        private void OnContinue()
        {
            ResumeInput();
        }

        [ContextMenu("Won")]
        private void OnWon()
        {
            _levelsManager.TryOpenNextLevel();
            Won?.Invoke();
        }

        
        [ContextMenu("ShowAll")]
        public void ShowAll()
        {
            PauseInput();
            _animator.TryPlay(_elements, OnAllShown);
        }

        [ContextMenu("FindMatch")]
        public void FindMatch()
        {
            PauseInput();
            var list = new List<Element>();
            
            Element first = null;
            if (_selectedElements.Count > 0)
            {
                first = _selectedElements[0];
            }
            else
            {
                first = _elements.First(e => !e.IsMatched);
                list.Add(first);
                _selectedElements.Add(first);
            }

            Element second = _elements.First(e => !e.IsMatched && e != first && e.Id.Equals(first.Id));
            _selectedElements.Add(second);
            list.Add(second);
            
            _animator.TryPlay(list, OnSelectedElementAnimated);
        }

        private void OnAllShown()
        {
            _coroutine = StartCoroutine(Pause(2, HideAll));
        }

        private void HideAll()
        {
            PauseInput();
            _animator.TryPlay(_elements, OnAllHidden);
        }

        private void OnAllHidden()
        {
            ResumeInput();
        }

        private void SubscribeForClick()
        {
            foreach (var element in _elements)
            {
                element.Init(OnElementClicked);
            }
        }

        private void OnElementClicked(Element element)
        {
            Debug.Log("Clicked");
            PauseInput();
            
            _selectedElements.Add(element);
            _animator.TryPlay(new List<Element>(){element}, OnSelectedElementAnimated);
        }
        
        private void OnSelectedElementAnimated()
        {
            _progressWatcher.Handle(_selectedElements);
        }

        private void PauseInput()
        {
            _signalBus.Fire<Core.GameSignals.UserInputPause>();
            ChangeInput(false);
        }
        
        private void ResumeInput()
        {
            _signalBus.Fire<Core.GameSignals.UserInputResume>();
            ChangeInput(true);
        }

        private void ChangeInput(bool value)
        {
            foreach (var element in _elements)
            {
                element.ChangeOnInputReaction(value);
            }
        }
        
        private IEnumerator Pause(int seconds, Action callback)
        {
            yield return new WaitForSeconds(seconds);
            callback?.Invoke();
        }

        public void Reset()
        {
            ClearSelected();
            ClearAll();

            if (!ReferenceEquals(_coroutine, null))
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            
            _builder.Clear();
        }
    }
}