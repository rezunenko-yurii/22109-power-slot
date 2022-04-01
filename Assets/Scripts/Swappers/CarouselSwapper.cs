using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using WheelLib;

namespace Swappers
{
    public class CarouselSwapper : Swapper
    {
        private ShiftyArray<LevelSwapperItem> _array;
        
        private int[] sib;
        private int[] showArray;

        [SerializeField] private Transform container;

        public bool CanUse = true;
        
        protected override void Awake()
        {
            base.Awake();

            if (!CanUse)
            {
                return;
            }
            
            Points = new float[items.Length];
            _array = new ShiftyArray<LevelSwapperItem>(items);
            sib = new int[_array.Length];

            CreateSiblingsOrder();
            CreateShowOrder();
        
            GetMovePoints();
            Swap();
        }

        private void CreateShowOrder()
        {
            if (showCount > _array.Length)
            {
                throw new Exception("Show count more than items");
            }
            else if (showCount < 3)
            {
                throw new Exception("Show count less than 3");
            }

            showArray = new int[showCount];
        
            int counter = _array.Length - 1;
            int num = 0;
        
            while (num < showCount)
            {
                foreach (int i in sib)
                {
                    if (sib[i] == counter)
                    {
                        showArray[num] = i;
                        num++;
                        counter--;
                    }
                }
            }
        }

        private void CreateSiblingsOrder()
        {
            int i = 0;
            int count = _array.Length - 1;
            int arrCount = _array.Length - 1;
        
            sib[count] = count;
            arrCount--;
            count--;
        
            while (count >= 0)
            {
                sib[arrCount] = count;
                arrCount--;
                count--;
            
                if (count >= 0)
                {
                    sib[i] = count;
                    count--;
                
                    i++;
                }
            }
        }

        private void Swap()
        {
            isAnimating = true;

            SetSiblingsPositions();

            var counter = 0;
            for (int i = _array.Length - 1; i >= 0; i--)
            {
                float moveTo = spacing * Points[counter];
                _array[i].Move(new Vector3(moveTo, 0, 0),moveSpeed);
                Debug.Log($"move i={i} to={moveTo} point={Points[counter]}");
                counter++;

                if (moveTo >= 0 && moveTo < 1 && i == _array.Length - 1)
                {
                    _array[i].Scale(new Vector3(1f, 1f, 0), moveSpeed, () =>
                    {
                        isAnimating = false;
                    });
                    _array[i].SetActive();
                }
                else
                {
                    _array[i].Scale(new Vector3(0.7f, 0.7f, 0),moveSpeed, null);
                    _array[i].SetInactive();
                }
            }

            var c = 0;
            foreach (Transform child in container.transform)
            {
                var item = items.First(i => i.transform.Equals(child));
                
                if (c == 0)
                {
                    Debug.Log($"Hide {child.name}");
                    item.Hide(moveSpeed);
                }
                else
                {
                    Debug.Log($"Show {child.name}");
                    item.Show(moveSpeed);
                }

                c++;
            }
            
        }

        private void SetSiblingsPositions()
        {
            int counter = 0;
        
            while (counter < _array.Length - 1)
            {
                foreach (int i in sib)
                {
                    if (sib[i] == counter)
                    {
                        _array[i].transform.SetSiblingIndex(counter);
                        counter++;
                    }
                }
            }
        }

        protected override void GetMovePoints()
        {
            Debug.Log($"{nameof(Wheel)} {nameof(GetMovePoints)}");
    
            float _period = 1;
            float _timer = 0;
            float tau = Mathf.PI * 2f;
            float m = _period / items.Length;

            for (int i = 0; i < items.Length; i++)
            {
                float currRad = (float) Math.Round(_timer * tau, 2);
                float rawSinWave = Mathf.Sin(currRad);

                if (rawSinWave < -1) rawSinWave = 0;
            
                Points[i] = rawSinWave;

                Debug.Log($"i={i} pos={rawSinWave} {_timer} {currRad}");

                _timer += m;
            }
        }

        protected override void OnSwipeRight()
        {
            if (isAnimating)
            {
                return;
            }
        
            _array.ShiftLeft();
            Swap();
        }

        protected override void OnSwipeLeft()
        {
            if (isAnimating)
            {
                return;
            }
        
            _array.ShiftRight();
            Swap();
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i].DOKill();
            }
        }
    }
}
