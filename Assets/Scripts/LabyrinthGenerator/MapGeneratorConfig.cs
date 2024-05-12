using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class MapGeneratorConfig
    {
        protected Random random;
        protected List<Room> rooms;

        protected MapGeneratorConfig()
        {
            random = new Random();
        }

        public abstract int roomsCount { get; }
        public abstract List<Room> CreateLevelMap();
    }    
}
