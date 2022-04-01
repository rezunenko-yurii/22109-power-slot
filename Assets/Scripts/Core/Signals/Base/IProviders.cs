using Core.Signals.GameSignals;

namespace Core.Signals.Base
{
    public interface ITakenProvider<TSignalTarget> where TSignalTarget : IIdentifier
    {
        void Handle(Taken<TSignalTarget> taken);
    }
    
    public interface IWonProvider<TSignalTarget> where TSignalTarget : IIdentifier
    {
        void Handle(Won<TSignalTarget> won);
    }
    
    public interface ITPurchasedProvider<TSignalTarget> where TSignalTarget : IIdentifier
    {
        void Handle(Purchased<TSignalTarget> purchased);
    }

    public interface IIncreasedProvider<TSignalTarget> where TSignalTarget : IIdentifier
    {
        void Handle(Increased<TSignalTarget> increased);
    }
}