using System;
using DG.Tweening;
using UnityEngine;

namespace Swappers
{
    public abstract class SwapperItem : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroup;

        protected bool isShown;
        //public abstract event Action OnMoved;
        public void Move(Vector3 position, float speed)
        {
            transform.DOLocalMove(position ,speed);
        }

        public void Scale(Vector3 size, float speed, Action callback)
        {
            transform.DOScale(size, speed).OnComplete(() => callback?.Invoke());
        }
        
        public void Show(float speed)
        {
            canvasGroup.DOFade(1, speed);
            /*if (!isShown)
            {
                canvasGroup.DOFade(1, speed);
                isShown = true;
            }*/
        }
        
        public void Hide(float speed)
        {
            canvasGroup.DOFade(0, speed);
            /*if (isShown)
            {
                canvasGroup.DOFade(0, speed);
                isShown = false;
            }*/
        }
        
        public abstract void SetActive();
        public abstract void SetInactive();
    }
}