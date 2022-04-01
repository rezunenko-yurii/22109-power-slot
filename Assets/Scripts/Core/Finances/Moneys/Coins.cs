using System;

namespace Core.Finances.Moneys
{
    [Serializable]
    public class Coins : Money
    {
        private const string CurrencyName = "Coins";
        public override string Name => CurrencyName;
        public override string Sign => string.Empty;
        public override string Type { get; protected set; } = "Coins";
    }
}