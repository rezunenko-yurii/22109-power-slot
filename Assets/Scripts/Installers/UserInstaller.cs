using System;
using System.Collections.Generic;
using Core.Collectables;
using Core.Finances.Moneys;
using Core.Finances.Wallets;
using Finances.Moneys;
using Finances.Payments;
using Finances.Payments.Unity;
using Finances.Wallets;

namespace Installers
{
    public class UserInstaller : AdvancedMonoInstaller
    {
        public override void InstallBindings()
        {
            CreateWallets();
            
            Create<CoinsPayment>();
            Create<UnityPayment>();
            Create<Payments>();
        }

        private void CreateWallets()
        {
            FloatCollectableObject coins = new FloatCollectableObject("coins",0);
            CoinsWallet coinsWallet = new CoinsWallet(coins);
            Container.Inject(coinsWallet);
            Container.Bind<CoinsWallet>().FromInstance(coinsWallet).AsSingle();
            
            FloatCollectableObject spinsCollectableObject = new FloatCollectableObject("spins",0);
            SpinsWallet spinsWallet = new SpinsWallet(spinsCollectableObject);
            Container.Inject(spinsWallet);
            Container.Bind<SpinsWallet>().FromInstance(spinsWallet).AsSingle();

            Dictionary<Type, IWallet> dictionary = new Dictionary<Type, IWallet>()
            {
                {typeof(Coins), coinsWallet},
                {typeof(Spins), spinsWallet},
            };
            
            var wallets = new Wallets(dictionary);
            Container.Bind<Wallets>().FromInstance(wallets).AsSingle();
        }
    }
}