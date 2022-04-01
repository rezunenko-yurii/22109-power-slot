using System;
using System.Collections.Generic;
using Core.Finances.Wallets;
using Core.Moneys;
using Finances.Moneys;
using Zenject;

namespace Finances.Wallets
{
    public class Wallets
    {
        private Dictionary<Type, IWallet> _dictionary;

        public Wallets(Dictionary<Type, IWallet> dictionary)
        {
            _dictionary = dictionary;
        }
        
        public void Add(IMoney money)
        {
            var wallet = Wallet(money.GetType());
            wallet.Add(money);
        }
        
        public void Subtract(IMoney money)
        {
            var wallet = Wallet(money.GetType());
            wallet.Subtract(money);
        }

        public IWallet Wallet(Type money)
        {
            return _dictionary[money];
        }

        public bool HasOnBalance(IMoney money)
        {
            var wallet = Wallet(money.GetType());
            return wallet.Balance() >= money.Amount;
        }
    }
}