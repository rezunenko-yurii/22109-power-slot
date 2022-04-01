using System;
using System.Linq;
using Core;
using MatchGame;
using UnityEngine;
using Zenject;

public class BoosterButtons : AdvancedMonoBehaviour
{
    public event Action<string> BoosterClicked;
    
    [Inject] private MatchBoostersList boostersList;
    
    public BoosterButton left;
    public BoosterButton right;

    [SerializeField] private DailyBonusItemData[] itemDatas;

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        
        if (boostersList.Names.Count >= 1)
        {
            left.gameObject.SetActive(true);
            
            var id = boostersList.Names[0];
            var d = itemDatas.First(x => x.productId.Equals(id));
            left.Id = id;
            left.SetData(d);
        }
        else
        {
            left.gameObject.SetActive(false);
        }
        
        if (boostersList.Names.Count >= 2)
        {
            right.gameObject.SetActive(true);
            
            var id = boostersList.Names[1];
            var d = itemDatas.First(x => x.productId.Equals(id));
            right.Id = id;
            right.SetData(d);
        }
        else
        {
            right.gameObject.SetActive(false);
        }
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        
        left.BoosterClicked += OnClicked;
        right.BoosterClicked += OnClicked;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        
        left.BoosterClicked -= OnClicked;
        right.BoosterClicked -= OnClicked;
    }

    private void OnClicked(string s)
    {
        BoosterClicked?.Invoke(s);
    }
}
