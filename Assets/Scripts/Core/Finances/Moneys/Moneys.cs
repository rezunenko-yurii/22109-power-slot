using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Core.Finances.Moneys
{
    public class Moneys
    {
        public Money Create(JToken token) => (string)token["Type"] switch
        {
            "Coins" => CreateCoins(token),
            "Dollars" => CreateDollars(token),
            _ => throw new Exception($"{typeof(Moneys)} cannot parse money with id {token["Type"]}")
        };
        
        private Money CreateCoins(JToken token)
        {
            float amount = (float) token["Amount"];
            Coins coins = new Coins {Amount = amount};

            return coins;
        }

        private Money CreateDollars(JToken token)
        {
            float amount = (float) token["Amount"];
            Dollars dollars = new Dollars {Amount = amount};

            return dollars;
        }
    }
}