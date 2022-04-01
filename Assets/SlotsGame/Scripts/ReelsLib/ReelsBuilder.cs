using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.ReelsLib
{
    public class ReelsBuilder
    {
        private DiContainer _container;
        private Transform _parent;
        private int _amount;
        private GameObject _prefab;
        private Reel[] _reels;
        
        private Vector2 _size;

        public void Build(GameObject prefab, int amount, Transform parent, DiContainer container, Vector2 fieldSize)
        {
            _prefab = prefab;
            _amount = amount;
            _parent = parent;
            _container = container;
            _size = fieldSize;
            
            Create();
            SetPositions();
        }
        
        private void Create()
        {
            _reels = new Reel[_amount];
            Vector2 reelSize = ReelSize();
        
            for (int i = 0; i < _reels.Length; i++)
            {
                _reels[i] = CreateReel();
                _reels[i].Init(reelSize);
            }
        }
        
        private Reel CreateReel()
        {
            return _container.InstantiatePrefabForComponent<Reel>(_prefab, _parent);
        }
        
        private Vector2 ReelSize()
        {
            var reelSize = Vector2.zero;
            reelSize.x = _size.x / _amount;
            reelSize.y = _size.y;

            return reelSize;
        }
        
        private void SetPositions()
        {
            Vector2 reelSize = ReelSize();
            float startPoint = -(_size.x / 2) + reelSize.x / 2;
            float step = startPoint;

            foreach (var reel in _reels)
            {
                reel.SetPositionX(step);
                step += reelSize.x;
            }
        }
        public Reel[] Reels() => _reels;
    }
}