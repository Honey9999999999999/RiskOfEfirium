namespace Assets.Scripts.LabyrinthGenerator
{
    public class BigRoom : Room
    {
        public BigRoom() : base(new()
        {
            new InterGBlock0(new(0, 2), Direction.Top),
            new SimpleBlock1(new(1, 2), Direction.Top),

            new InterGBlock0(new(2, 2), Direction.Right),
            new SimpleBlock1(new(2, 1), Direction.Right),

            new InterGBlock0(new(2, 0), Direction.Down),
            new SimpleBlock1(new(1, 0), Direction.Down),

            new InterGBlock0(new(0, 0), Direction.Left),
            new SimpleBlock1(new(0, 1), Direction.Left),

            new InterBlock0(new(1, 1))
        })
        {
            variableTypes.Add(0.1f, RoomType.CommandRoom);
        }

        protected override void SetRandomTypeRoom()
        {
            SetTypeRoom(variableTypes.GetValue());
        }
    }
}
