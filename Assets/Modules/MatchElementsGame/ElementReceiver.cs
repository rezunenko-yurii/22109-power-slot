using System;
using Core;
using DefaultNamespace;
using GameCores.MatchElementsGame;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class ElementReceiver : AdvancedMonoBehaviour
{
    public event Action Added;
    
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private ElementPointer pointer;
    [SerializeField] private Image back;
    
    public Element pickedElement;

    public void SetData(Element element)
    {
        if(element == null) return;
        pickedElement = element;
        
        pickedElement.transform.position = rectTransform.position;
        back.color = new Color(back.color.r,back.color.g, back.color.b, 0f);
        
        Added?.Invoke();
    }

    public void Clean()
    {
        pickedElement = null;
        back.color = new Color(back.color.r,back.color.g, back.color.b, 1f);
    }

    public bool HasElement => pickedElement != null;

    public bool Compare(Element element) => pickedElement.Sprite.Equals(element.Sprite);
}
