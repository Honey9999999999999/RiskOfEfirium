using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class SimpleRoom : Room
    {
        public SimpleRoom() : base(new List<Block>()
        {
            new SimpleBlock4(new(0, 0))
        })
        {
            variableTypes.Add(1, RoomType.CargoRoom);
            variableTypes.Add(1, RoomType.HibernationRoom);
        }

        protected override void SetRandomTypeRoom()
        {
            SetTypeRoom(variableTypes.GetValue());
        }
    }
}
