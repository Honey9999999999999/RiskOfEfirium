using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class MapGeneratorConfig
    {
        public abstract int roomsCount { get; }
        public abstract List<Room> CreateLevelMap();
    }
}
