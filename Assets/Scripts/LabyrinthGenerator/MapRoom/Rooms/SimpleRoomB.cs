namespace Assets.Scripts.LabyrinthGenerator
{
    internal class SimpleRoomB : Room
    {
        public SimpleRoomB() : base(new()
        {
            new SimpleBlock2(new(0, 0), Direction.Top)
        })
        {
        }
    }
}
