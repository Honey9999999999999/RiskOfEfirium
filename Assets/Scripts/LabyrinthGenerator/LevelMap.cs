using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class LevelMap
    {
        public List<Room> rooms { get; private set; }
        public MapGeneratorConfig config { get; private set; }

        public LevelMap(MapGeneratorConfig config)
        {
            this.config = config;
            rooms = config.CreateLevelMap();
        }

        public void Rotate()
        {
            foreach (var room in rooms)
            {
                room.Rotate();
            }
        }

        public bool TryGetRoom(IntVector2 position, out Room room)
        {
            foreach (var r in rooms)
            {
                if(r.position == position)
                {
                    room = r;
                    return true;
                }
            }

            room = null;
            return false;
        }
    }
}
