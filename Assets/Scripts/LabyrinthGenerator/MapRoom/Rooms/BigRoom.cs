namespace Assets.Scripts.LabyrinthGenerator
{
    public class BigRoom : Room
    {
        public BigRoom() : base(new()
        {
            new InterGBlock1(new(0, 0), Direction.Top),
            new InterTBlock0(new(1, 0), Direction.Top),

            new InterGBlock1(new(2, 0), Direction.Right),
            new InterTBlock0(new(2, -1), Direction.Right),

            new InterGBlock1(new(2, -2), Direction.Down),
            new InterTBlock0(new(1, -2), Direction.Down),

            new InterGBlock1(new(0, -2), Direction.Left),
            new InterTBlock0(new(0, -1), Direction.Left),

            new InterBlock0(new(1, -1))
        })
        {
        }
    }
}
