namespace SlotsGame.Scripts.Lines
{
    public class Line
    {
        public LineBlueprint Blueprint { get; private set; }
        public Line(LineBlueprint blueprint)
        {
            Blueprint = blueprint;
        }

        public bool IsActive { get; set; }
    }
}