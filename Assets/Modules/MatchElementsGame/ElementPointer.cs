using System;
using Core;
using GameCores.MatchElementsGame;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ElementPointer : AdvancedMonoBehaviour
    {
        public bool Follow;
        private Image image;
        private RectTransform rectTransform;

        public Element PickedElement;
        protected override void Awake()
        {
            base.Awake();
        
            image = GetComponent<Image>();
            rectTransform = GetComponent<RectTransform>();
        }
        
        public void SetData(Element element)
        {
            PickedElement = element;
            image.sprite = element.Sprite;
            image.SetNativeSize();
            Color c = image.color;
            image.color = new Color(c.g, c.r, c.b, 1f);
        }

        private void Update()
        {
            if (Follow)
            {
                transform.position = Input.mousePosition;
            }
        }

        public void Clean()
        {
            Follow = false;
            image.sprite = null;
            PickedElement = null;
            
            Color c = image.color;
            image.color = new Color(c.g, c.r, c.b, 0f);
        }
    }
}