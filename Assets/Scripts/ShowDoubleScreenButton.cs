using Core.Buttons;
using SlotsGame.Scripts;
using SlotsGame.Scripts.Combinations;
using Zenject;

public class ShowDoubleScreenButton : ScreenButton
{
    [Inject] private SignalBus _signalBus;
    private CombinationHolder _combinationHolder;
    private bool isPlayed = false;

    protected override void Start()
    {
        base.Start();
            
        //ChangeInteractableState(false);
    }

    [Inject]
    private void Init(CombinationHolder combinationHolder)
    {
        _combinationHolder = combinationHolder;
    }

    protected override void OnClick()
    {
        base.OnClick();
        return;
        if (CanPlay())
        {
            isPlayed = true;
            base.OnClick();
                
            ChangeInteractableState(false);
        }
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        _signalBus.Subscribe<SlotSignals.EffectsEnded>(Reset);
    }
        
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        _signalBus.Unsubscribe<SlotSignals.EffectsEnded>(Reset);
    }

    private void Reset()
    {
        isPlayed = false;
            
        if (CanPlay())
        {
            ChangeInteractableState(true);
        }
    }

    private bool CanPlay()
    {
        var winCombinations = _combinationHolder.GetWinCombinations();
        if (winCombinations.Count > 0 && !isPlayed)
        {
            return true;
        }

        return false;
    }
}