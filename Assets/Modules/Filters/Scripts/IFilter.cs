namespace Modules.Filters.Scripts
{
    public interface IFilter
    {
        string Id { get; }
        void Init();
        bool IsRequestSatisfied();
    }
}