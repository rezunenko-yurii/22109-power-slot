using System;
using Core;
using SlotsGame.Scripts.ReelsLib;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.BoardLib
{
    public class Board : AdvancedMonoBehaviour
    {
        public event Action Over;
        
        [Inject] private Reels _reels;

        [SerializeField] private Transform container;
        [SerializeField] private BoardAnimController controller;
        [SerializeField] private Vector2 _fieldSize;

        public void Init()
        {
            _reels.Init(container, _fieldSize);
        }
        
        private void OnAnimOver()
        {
            Over?.Invoke();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            controller.OnSpinOver += OnAnimOver;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            controller.OnSpinOver -= OnAnimOver;
        }
        
        public void Play()
        {
            HideCombinations();
            controller.Play();
        }

        public void ShowCombinations()
        {
            _reels.ShowCombinations();
        }

        public void HideCombinations()
        {
            _reels.HideCombinations();
        }

        public void Appear()
        {
            _reels.Appear();
        }

        public void Prepare()
        {
            _reels.Prepare();
        }

        public void Stop()
        {
            controller.Stop();
        }
    }
}