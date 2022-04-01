namespace GameCores.MemoryMatchGame
{
    public class Level
    {
        public string Id { get; init; }
        public int LevelNum { get; init; }
        public int Attempts { get; init; }
        public int Time { get; init; }
        public int Rows { get; init; }
        public int Cols { get; init; }
        public int[,] Field { get; init; }
    }
}