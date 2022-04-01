using Core;
using MatchGame;
using TMPro;
using UnityEngine;
using Zenject;

public class HintAmountText : AdvancedMonoBehaviour
{
    [Inject] private MatchBoostersList boostersList;
    [SerializeField] private TextMeshProUGUI textfield;

    protected override void AddListeners()
    {
        base.AddListeners();
        boostersList.Changed += OnChanged;
    }
        
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        boostersList.Changed -= OnChanged;
    }
        
    private void OnChanged()
    {
        textfield.text = $"{boostersList.Names.Count} / 2";
    }
}