using System;
using Core.Finances.Moneys;
using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using Finances.Moneys;
using GameSignals;
using LevelsModule;
using SlotsGame.Scripts.AutoSpins;
using SlotsGame.Scripts.Bets;
using SlotsGame.Scripts.Effects;
using UnityEngine;
using WalletsImp;
using Zenject;

namespace SlotsGame.Scripts.Combinations
{
    public class CombinationRewards
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private CombinationHolder _combination;
        [Inject] private BetsManager _betsManager;

        [Inject] private AutoSpin _autoSpin;
        [Inject] private EffectsManager _effectsManager;
        [Inject] private Scores _scores;
        
        public void GetSpinReward()
        {
            Debug.Log($"{nameof(CombinationRewards)} {nameof(GetSpinReward)}");
            
            _scores.Add(50);

            var winCombinations = _combination.GetWinCombinations();

            foreach (var winCombination in winCombinations)
            {
                foreach (var reward in winCombination.SlotBlueprint.Rewards)
                {
                    Debug.Log($"{nameof(CombinationRewards)} {nameof(GetSpinReward)} Get reward of type {reward.GetType()}");
                    
                    switch (reward)
                    {
                        case MoneyCombinationReward money:
                            GetMoneyReward(money, winCombination);
                            break;
                        case FreeSpinsCombinationReward freeSpins:
                            GetFreeSpinsReward(freeSpins);
                            break;
                        /*case MoneyMultiplier moneyMultiplier:
                            GetMoneyMultiplierReward(moneyMultiplier);
                            break;*/
                        default: throw new NotImplementedException($"Can`t find handler for reward {reward.GetType()}");
                    }
                }
            }
        }

        /*private void GetMoneyMultiplierReward(MoneyMultiplier moneyMultiplier)
        {
            //_moneyBooster.Add(moneyMultiplier.multiplier, moneyMultiplier.amount);
        }*/

        private void GetFreeSpinsReward(FreeSpinsCombinationReward freeSpins)
        {
            if (_autoSpin.Type.Equals(AutoSpinType.ForcedAmount)) return;

            Spins spins = new Spins {Amount = freeSpins.amount};

            Debug.Log($"Win spins -> {spins.Amount}");
            
            _signalBus.Fire(new Won<Spins>(spins));
            _effectsManager.AddToQuery(EffectsTypes.FreeSpins);

            _autoSpin.TransitionTo(AutoSpinType.ForcedAmount, freeSpins.amount);
        }

        private void GetMoneyReward(MoneyCombinationReward moneyReward, WinCombination winCombination)
        {
            var payoutMap = moneyReward.CalculateBestPayout(winCombination.Cells.Count);
            var reward = payoutMap.coefficient * _betsManager.Current;

            var coins = new Coins {Amount = reward};
            
            Debug.Log($"Win coins -> {coins.Amount}");
            
            _signalBus.Fire(new Won<Coins>(coins));
        }
    }
}