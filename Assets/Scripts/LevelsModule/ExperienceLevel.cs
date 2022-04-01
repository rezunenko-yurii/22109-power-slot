using Core.Signals.Base;

namespace LevelsModule
{
    public class ExperienceLevel : IIdentifier
    {
        public int Level;
        public int Amount;
        public string ProductId;
        public string Id { get; }
        public string Type { get; } = "ExperienceLevel";
    }
}