using System;
using UnityEngine;
using WheelLib;

namespace Swappers
{
    public class LinearSwapper : Swapper
    {
        protected override void Awake()
        {
            base.Awake();

            CalculatePoints();
        }

        private void CalculatePoints()
        {
            int amount = (items.Length - 1) * 2;
            Points = new float[amount + 1];
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
            
                //Points[i] = rawSinWave;

                Debug.Log($"i={i} pos={rawSinWave} {_timer} {currRad}");

                _timer += m;
            }
        }

        /*protected override void GetMovePoints()
        {
            float currPos = 0f;
            
            for (int i = 0; i < items.Length; i++)
            {
                Points[i] = currPos;
                currPos += spacing;
            }
        }*/

        protected override void OnSwipeLeft()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnSwipeRight()
        {
            throw new System.NotImplementedException();
        }
    }
}