using System;
using UnityEngine;

namespace Core.Finances.Moneys
{
    [Serializable]
    public sealed class Dollars : Money
    {
        private const string CurrencyName = "Dollar";
        public override string Name => CurrencyName;
        public override string Sign => "$";
        public override string Type { get; protected set; } = "Dollar";
    }
}