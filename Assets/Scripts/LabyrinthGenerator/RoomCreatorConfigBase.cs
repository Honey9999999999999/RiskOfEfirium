using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class RoomCreatorConfigBase
    {
        internal delegate Room RoomCreator<T>();
        private readonly Dictionary<float, RoomCreator<Room>> _chanceMap;

        internal RoomCreatorConfigBase(Dictionary<float, RoomCreator<Room>> chanceMap)
        {
            _chanceMap = UpdateChances(chanceMap);
        }
        

        private Dictionary<float, RoomCreator<Room>> UpdateChances(Dictionary<float, RoomCreator<Room>> chanceMap)
        {
            float summ = 0;

            foreach (var chance in chanceMap.Keys)
            {
                summ += chance;
            }

            Dictionary<float, RoomCreator<Room>> _chanceMap = new();

            foreach (var chance in chanceMap.Keys)
            {
                _chanceMap.Add(chance / summ, chanceMap[chance]);
            }

            return _chanceMap;
        }
        

        protected static Room CreateRandomRoom<TType>() where TType : Room, new()
        {
            return new TType();
        }
        public Room CreateRandomRoom()
        {
            float chance = Random.Range(0f, 1f);

            float summChance = 0;

            foreach (var key in _chanceMap.Keys)
            {
                summChance += key;

                if(summChance >= chance)
                {
                    return _chanceMap[key]();
                }
            }

            throw new System.Exception("Imposible chance");
        }
    }
}
