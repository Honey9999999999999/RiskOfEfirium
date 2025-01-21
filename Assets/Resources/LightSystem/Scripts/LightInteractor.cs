using System.Collections.Generic;
using Architecture;
using Assets.Resources.LightSystem.Scripts;
using Assets.Resources.MapSystem.Scripts;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

public class LightInteractor : Interactor
{
    private Light light;
    private LightConfig lightConfig;

    private RoomType currentRoom = RoomType.UnTyped;

    public override void Initialize()
    {
        base.Initialize();        
    }

    public override void OnCreate()
    {
        base.OnCreate();

        light = ResourceLoader.Load<Light>("LightSystem/Prefabs/Directional Light");
        lightConfig = new();
    }

    public override void OnStart()
    {
        base.OnStart();
    }


    public void LoadRoomLightSetings(RoomLight roomLight)
    {
        if(currentRoom != roomLight.type)
        {
            List<Texture2D> lightMaps = lightConfig.GetLightMaps(roomLight.type);

            // Назначаем текстуры Lightmap (глобально для сцены)
            LightmapData[] lightmapData = new LightmapData[lightMaps.Count];
            
            for(int i = 0; i < lightMaps.Count; i++)
            {
                lightmapData[i] = new LightmapData
                {
                    lightmapColor = lightMaps[i]
                };
            }

            LightmapSettings.lightmaps = lightmapData;
        }

        light.enabled = roomLight.isGeneralLighting;
        light.color = roomLight.isGeneralLighting ? roomLight.ambientColor : Color.black;
        RenderSettings.ambientLight = roomLight.isGeneralLighting ? roomLight.ambientColor : Color.black;
    }

}
