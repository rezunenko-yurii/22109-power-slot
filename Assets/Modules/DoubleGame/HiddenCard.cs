using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DoubleGameLib
{
    public class HiddenCard : DoubleGameResult
    {
        [SerializeField] private Image back;
        [SerializeField] private Image item;
        
        [SerializeField] private Sprite red;
        [SerializeField] private Sprite blue;
        
        [SerializeField] private Sprite backSide;
        [SerializeField] private Sprite frontSide;
        
        
        private Sequence shakeSequence;

        private void Awake()
        {
            Hide();
        }

        public void Hide()
        {
            back.sprite = backSide;
            back.SetNativeSize();

            SetNewType();
        }
        
        
        public override void SetNewType()
        {
            CardType = (DoubleCardType) Random.Range(0, 2);
        }
        

        public override void Apply(Action callback)
        {
            SetNewType();
            shakeSequence = DOTween.Sequence();
            shakeSequence
                .Append(item.DOFade(0, 0.3f))
                .Append(transform.DOLocalRotate(new Vector3(0, 360 * 7, 0), 1f, RotateMode.FastBeyond360))
                .AppendCallback(ShowRes)
                .Append(item.DOFade(1, 0.3f))
                .AppendCallback(() => callback?.Invoke());
        }

        private void ShowRes()
        {
            if (CardType.Equals(DoubleCardType.Red))
            {
                item.sprite = red;
                item.SetNativeSize();
            }
            else
            {
                item.sprite = blue;
                item.SetNativeSize();
            }
        }
        
        private void OnDisable()
        {

            item.color = new Color(item.color.r, item.color.g, item.color.b, 0);
            shakeSequence.Kill();
        }
    }
}