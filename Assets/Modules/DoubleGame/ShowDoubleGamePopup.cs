using Core.Popups.Buttons;
using SlotsGame.Scripts;
using SlotsGame.Scripts.Combinations;
using UnityEngine;
using Zenject;

public class ShowDoubleGamePopup : PopupButton
{
    [Inject] private CombinationHolder _combinationHolder;
    [Inject] protected SignalBus signalBus;
    
    [SerializeField] private GameObjectContext _context;
    [SerializeField] private string popupId;
    
    private bool isPlayed = false;
    
    protected override void Initialize()
    {
        base.Initialize();
        OnChanged();
        ChangeInteractableState(false);
    }
    
    protected override void AddListeners()
    {
        base.AddListeners();
        signalBus.Subscribe<SlotSignals.EffectsEnded>(Reset);
        //_combinationHolder.Changed += OnChanged;
    }
    
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        signalBus.Unsubscribe<SlotSignals.EffectsEnded>(Reset);
        //_combinationHolder.Changed -= OnChanged;
    }
    
    protected override void OnClick()
    {
        if (CanPlay())
        {
            isPlayed = true;
            base.OnClick();
                    
            //var popup = _context.Container.InstantiatePrefabForComponent<Popup>(popupPrefab, PopupsManager.GetRoot);
            PopupsManager.Show(popupId);
                        
            ChangeInteractableState(false);
        }
    }
    
    private void OnChanged()
    {
        isPlayed = false;
        
    }
        
    private void Reset()
    {
        isPlayed = false;
             
        if (Button.IsInteractable())
        {
            ChangeInteractableState(CanPlay());
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

    public override void ChangeInteractableState(bool isClickable)
    {
        Button.interactable = isClickable && CanPlay();
    }
}