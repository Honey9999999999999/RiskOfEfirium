using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator.MapRoom.Rooms
{
    public class CloseRoom : Room
    {
        public CloseRoom() : base(new()
        {
            new SimpleBlock1 (new(0, 0), Direction.Top)
        })
        {
        }
    }
}
