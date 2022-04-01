using System;
using Core;

namespace DoubleGameLib
{
    public abstract class DoubleGameResult : AdvancedMonoBehaviour
    {
        public DoubleCardType CardType { get; set; }

        public abstract void SetNewType();

        public abstract void Apply(Action callback);
    }
}