namespace Core.Moneys
{
    public interface IMoney
    {
        float Amount { get; set; }
        string Name { get; }
        string FullName { get; }
        string Sign { get; }
    }
}