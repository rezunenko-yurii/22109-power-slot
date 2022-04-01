using System;
using Core;
using GameCores.MatchElementsGame;
using UnityEngine;

public class ElementsComparer : AdvancedMonoBehaviour
{
    public event Action<Element,Element> Matched;
    
    [SerializeField] private ElementReceiver leftReceiver;
    [SerializeField] private ElementReceiver rightReceiver;

    protected override void AddListeners()
    {
        base.AddListeners();
        
        leftReceiver.Added += Compare;
        rightReceiver.Added += Compare;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        
        leftReceiver.Added -= Compare;
        rightReceiver.Added -= Compare;
    }

    private void Compare()
    {
        if (leftReceiver.HasElement && rightReceiver.HasElement)
        {
            if (leftReceiver.Compare(rightReceiver.pickedElement))
            {
                Matched?.Invoke(leftReceiver.pickedElement, rightReceiver.pickedElement);
                
                leftReceiver.Clean();
                rightReceiver.Clean();
            }
        }
    }

    public void Clean()
    {
        leftReceiver.Clean();
        rightReceiver.Clean();
    }
}
