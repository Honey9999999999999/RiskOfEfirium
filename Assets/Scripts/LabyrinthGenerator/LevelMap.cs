using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class LevelMap
    {
        public List<Room> _map { get; private set; }
        public MapGeneratorConfig config { get; private set; }

        public LevelMap(MapGeneratorConfig config)
        {
            this.config = config;
            _map = config.CreateLevelMap();
        }
    }
}
