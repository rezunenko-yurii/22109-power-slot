using System;
using UnityEngine;

namespace Swappers
{
    [RequireComponent(typeof(SwipeDetector))]
    public abstract class Swapper : MonoBehaviour
    {
        [SerializeField] protected LevelSwapperItem[] items;
        [SerializeField] protected int showCount;
        [SerializeField] protected int spacing;
        [SerializeField] protected float moveSpeed;
        protected float[] Points;
        protected SwipeDetector swipeDetector;
        protected bool isAnimating = false;
        
        protected virtual void Awake()
        {
            swipeDetector = GetComponent<SwipeDetector>();
            swipeDetector.OnSwipeLeft += OnSwipeLeft;
            swipeDetector.OnSwipeRight += OnSwipeRight;
        }
        
        protected abstract void GetMovePoints();
        protected abstract void OnSwipeLeft();
        protected abstract void OnSwipeRight();
    }
}