using DailyBonusModule;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class DailyBonuReadyState : DailyBonusState
{
    [SerializeField] private Sprite sprite;
    [Inject] private DailyBonusesManager _bonusesManager;
    protected override DailyBonusStates State { get; } = DailyBonusStates.Ready;

    private Sequence shakeSequence;
    
    public override void Apply()
    {
        Context.Skin.sprite = sprite;
        
        Context.Button.gameObject.SetActive(true);
        Context.Button.onClick.AddListener(OnClicked);
        
        /*shakeSequence = DOTween.Sequence();
        shakeSequence.SetLoops(-1)
            .PrependInterval(1.5f)
            .Append(Context.transform.DOShakeRotation(1f, 30f));*/
    }

    public override void BeforeChanged()
    {
        Context.Button.onClick.RemoveListener(OnClicked);
        Context.Button.gameObject.SetActive(false);
    }

    public override bool CanApply(int itemDay, int currentDay, int passedDay)
    {
        return currentDay == itemDay && passedDay >= 1;
    }

    private void OnClicked()
    {
        /*shakeSequence.Complete();
        shakeSequence.Kill();
        
        Context.transform.localScale = Vector2.one;
        Context.transform.transform.rotation = Quaternion.Euler (new Vector2 (0,0));*/
        
       // Context.SetState(DailyBonusStates.Opened);
       _bonusesManager.GiveBonus();
       Context.OnChanged();
    }

    private void OnDestroy()
    {
        shakeSequence.Kill();
    }
}
