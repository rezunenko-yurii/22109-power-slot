using Core;
using UnityEngine;

namespace Carousel
{
    public class Carousel : AdvancedMonoBehaviour
    {
        [SerializeField] private GameObject[] items;
        [SerializeField] private Transform pointsContainer;

        private CarouselItem[] _carouselItems;

        protected override void Awake()
        {
            base.Awake();
            LoadPoints();
        }

        private void LoadPoints()
        {
            _carouselItems = pointsContainer.GetComponentsInChildren<CarouselItem>();
        }
    }
}