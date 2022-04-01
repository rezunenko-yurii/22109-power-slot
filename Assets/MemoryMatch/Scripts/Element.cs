using System;
using Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MemoryMatch.Scripts
{
    [RequireComponent(typeof(Image))]
    public class Element : AdvancedMonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _back;
        [field: SerializeField] public SwapAnim SwapAnim { get; private set; }

        private Sprite _front;
        private bool _canReactOnUserInput = true;
        private Action<Element> _onClickCallback;
        
        public int Id { get; private set; }
        public bool IsShown { get; private set; }
        public bool IsMatched;
        
        public void Init(Action<Element> onClickCallback)
        {
            _onClickCallback = onClickCallback;
        }
        
        public void ChangeOnInputReaction(bool value)
        {
            _canReactOnUserInput = value;
        }

        public void SetData(int id, Sprite front)
        {
            Id = id;
            _front = front;
        }

        public void Show()
        {
            ChangeState(_front, true);
        }

        public void Hide()
        {
            ChangeState(_back, false);
        }

        private void ChangeState(Sprite sprite, bool state)
        {
            SetSprite(sprite);
            IsShown = state;
        }

        private void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            if (_canReactOnUserInput && !IsShown)
            {
                _onClickCallback(this);
            }
        }

        public void OnPointerDown(PointerEventData eventData) { }
    }
}