using System;
using Core;
using Core.CurvedAnimations;
using Core.Finances.Store.Products;
using UnityEngine;
using Zenject;

namespace WheelLib
{
    public class Wheel : AdvancedMonoBehaviour
    {
        public event Action Spun;

        [Inject] private ProductBundlesSets _productBundlesSets;
        
        [SerializeField] private string sectorsRewardsIds;
        
        [SerializeField] private Transform wheelTransform;
        [SerializeField] private float pointerDegree = 0f;
        [SerializeField] private float shiftFromPointer = 0f;

        [SerializeField] private RotationCurveAnimation rotationAnimation;

        public ProductBundlesSet SectorsRewards { get; private set; }
        public bool Spinning => !rotationAnimation.CanPlay;

        protected override void Initialize()
        {
            base.Initialize();
            SectorsRewards = _productBundlesSets.GetObject(sectorsRewardsIds);
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            rotationAnimation.Ended += OnSpun;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            rotationAnimation.Ended -= OnSpun;
        }
        
        [ContextMenu("Spin")]
        public void TrySpin()
        {
            rotationAnimation.TryPlay();
        }
        
        private void OnSpun()
        {
            //float angle = CorrectAngle(wheelTransform.eulerAngles.z);
            Spun?.Invoke();
        }

        private float CorrectAngle(float angle)
        {
            float currentAngle = angle + pointerDegree - shiftFromPointer;
            float checkedAngle = currentAngle - 360f;
            
            return checkedAngle >= 0f ? checkedAngle : currentAngle;
        }

        public int GetSectorPosition()
        {
            float angle = CorrectAngle(wheelTransform.eulerAngles.z);
            var sectorSize = 360 / SectorsRewards.Lists.Count;
            var sectorPosition = (int) angle / sectorSize;
            
            return sectorPosition;
        }
    }
}
