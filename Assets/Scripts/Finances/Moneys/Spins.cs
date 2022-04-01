using System;
using Core.Finances.Moneys;
using Core.Moneys;
using UnityEngine;

namespace Finances.Moneys
{
    [Serializable]
    public class Spins : Money
    {
        private const string CurrencyName = "Spins";
        public override string Name => CurrencyName;
        public override string Sign => string.Empty;
        public override string Type { get; protected set; } = "Spins";
    }
}