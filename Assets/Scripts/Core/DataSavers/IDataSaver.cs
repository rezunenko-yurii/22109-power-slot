namespace Core.DataSavers
{
    public interface IDataSaver<T>
    {
        string Id { get; set; }
        T Value { get; }
        T DefaultValue { get; set; }
        void Load();
        void SetValue(T value);
    }
}