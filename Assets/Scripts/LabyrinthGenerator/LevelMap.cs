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
    }
}
