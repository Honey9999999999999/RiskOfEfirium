namespace Assets.Scripts.LabyrinthGenerator
{
    public class BigRoom : Room
    {
        public BigRoom() : base(new()
        {
            new SimpleBlock0(new(0, 2)),
            new SimpleBlock1(new(1, 2), Direction.Top),

            new SimpleBlock0(new(2, 2)),
            new SimpleBlock1(new(2, 1), Direction.Right),

            new SimpleBlock0(new(2, 0)),
            new SimpleBlock1(new(1, 0), Direction.Down),

            new SimpleBlock0(new(0, 0)),
            new SimpleBlock1(new(0, 1), Direction.Left),

            new SimpleBlock0(new(1, 1))
        })
        {
        }
    }
}
