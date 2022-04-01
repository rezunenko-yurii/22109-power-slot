using Core.Signals.Base;

namespace Core.Finances.Store.Products
{
    public interface IProduct : IIdentifier
    {
        string Description { get; }
    } 
}