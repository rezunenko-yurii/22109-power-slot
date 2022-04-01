using Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameCores.MatchElementsGame
{
    public class Element : AdvancedMonoBehaviour
    {
        private RectTransform rectTransform;
        private Image image;
        public Sprite Sprite { get; private set; }
        public Vector2 positionBeforeDrag;
        protected override void Awake()
        {
            base.Awake();
        
            image = GetComponent<Image>();
            rectTransform = GetComponent<RectTransform>();
        }

        public void SetData(Sprite sprite)
        {
            Sprite = sprite;
            image.sprite = sprite;
            image.SetNativeSize();
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta;
        }

        public void SetPosition(float x, float y)
        {
            rectTransform.localPosition = new Vector2(x, y);
        }
    }
}
