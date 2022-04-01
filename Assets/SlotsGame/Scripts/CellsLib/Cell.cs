using SlotsGame.Scripts.Animation;
using SlotsGame.Scripts.ChipsLib;
using SlotsGame.Scripts.Slot;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.CellsLib
{
    public class Cell : MonoBehaviour
    {
        [Inject] private Config _config;
        [Inject] private DiContainer _container;
        
        private Transform _rectTransform;
        private Vector2 _size;

        public Chip chip;
        public Selector selector;
        
        [SerializeField] public CellAnimController controller;

        public void Init(Vector2 size)
        {
            _rectTransform = GetComponent<Transform>();
            SetSize(size);

            Create();
        }

        private void Create()
        {
            selector = _container.InstantiatePrefabForComponent<Selector>(_config.reelsBlueprint.selectorPrefab, _rectTransform);
            
            chip = _container.InstantiatePrefabForComponent<Chip>(_config.reelsBlueprint.chipPrefab, _rectTransform);
            chip.Init();
        }

        private void SetSize(Vector2 newSize)
        {
            _size = newSize;
            //_rectTransform.sizeDelta = _size;
        }

        public void SetPositionY(float y)
        {
            _rectTransform.localPosition = new Vector2(0, y);
        }
    }
}