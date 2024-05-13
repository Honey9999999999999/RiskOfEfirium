namespace Assets.Scripts.LabyrinthGenerator
{
    public class MediumRoom : Room
    {
        public MediumRoom() : base(new()
        {
            new InterGBlock1(new(0, 0), Direction.Top),
            new InterGBlock1(new(1, 0), Direction.Right),
            new InterGBlock1(new(1, -1), Direction.Down),
            new InterGBlock1(new(0, -1), Direction.Left)
        })
        {
        }
    }
}
