using Core;
using Core.CustomTimeline.Base;
using Core.Finances.Moneys;
using Core.Finances.Store.Products;
using DailyReward;
using GameSignals;
using Modules.Dates;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using Zenject;
using Product = Core.Finances.Store.Products.Product;

public class DailyBonusLogic : AdvancedMonoBehaviour
{
    [Inject] private Products _products;

    [Inject(Id = ModuleType.DailyBonus)] public EveryDayCounter counter;
    [Inject(Id = ModuleType.DailyBonus)] public NextDateKeeper nextDateKeeper;
    [Inject] private SignalBus _signalBus;
    
    [SerializeField] private Button boxesButton;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private Image rewardImage;
    [SerializeField] private TextMeshProUGUI rewardText;

    [field: SerializeField]
    private DailyBonusItemData[] dailyBonusItems;

    private DailyBonusItemData current;
    private Product currentProduct;

    private bool isTaken;

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        int i = Random.Range(0, dailyBonusItems.Length);
        current = dailyBonusItems[i];

        isTaken = false;
        director.Reset();

        SetData();
    }

    private void SetData()
    {
        currentProduct = _products.GetObject(current.productId);

        rewardImage.sprite = current.sprite;
        string amountText = current.amount > 1 ? $"{current.amount} X " : string.Empty;
        rewardText.text = $"Your Bonus:\n{amountText}{currentProduct.Description}";
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        boxesButton.onClick.AddListener(PlayAnimation);
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        boxesButton.onClick.RemoveListener(PlayAnimation);
    }

    private void PlayAnimation()
    {
        if (director.state != PlayState.Playing && !isTaken)
        {
            GiveReward();
            director.Play();
        }
    }

    private void GiveReward()
    {
        //_signalBus.Fire(new Won<Coins>(currentProduct));
        
        isTaken = true;
        counter.Update();
        nextDateKeeper.AddHoursFromNow(24);
    }
}
