using Core.Buttons;
using UnityEngine;

public class ShareButton : AdvancedButtonUI
{
    [SerializeField] private string url;
    protected override void OnClick()
    {
        base.OnClick();
        
        new NativeShare().SetText(url)
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }
}
