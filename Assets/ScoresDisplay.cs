using Core;
using LevelsModule;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoresDisplay : AdvancedMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [Inject] private Scores _scores;
    
    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        Check(_scores.Amount);
    }

    private void Check(int savedScoresAmount)
    {
        _textMeshProUGUI.text = savedScoresAmount.ToString();
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        _scores.Changed += Check;
    }
        
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        _scores.Changed -= Check;
    }
}
