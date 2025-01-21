using System.Collections.Generic;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

namespace Assets.Resources.LightSystem.Scripts
{
    public class LightConfig
    {
        private Dictionary<RoomType, List<string>> lightMapConfig = new()
        {
            [RoomType.Armory] = new List<string>()
            {
                "LightSystem/LightMaps/Lightmap-1_comp_light"
            }
        };

        public List<Texture2D> GetLightMaps(RoomType roomType)
        {
            List<Texture2D> lightMaps = new();

            foreach (var path in lightMapConfig[roomType])
            {
                lightMaps.Add(ResourceLoader.Load<Texture2D>(path));
            }

            return lightMaps;
        }
    }
}