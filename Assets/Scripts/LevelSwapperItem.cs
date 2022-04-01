using DG.Tweening;
using Swappers;
using UnityEngine;
using UnityEngine.UI;

public class LevelSwapperItem : SwapperItem
{
    [SerializeField] protected GameObject button;
    [SerializeField] protected Image Image;
    
    public override void SetActive()
    {
        if (button != null)
        {
            button.gameObject.SetActive(true);
        }
        
        //Image.DOFade(1, 0.2f);
    }

    public override void SetInactive()
    {
        if (button != null)
        {
            button.gameObject.SetActive(false);
        }

        //Image.DOFade(0.5f, 0.2f);
    }
}