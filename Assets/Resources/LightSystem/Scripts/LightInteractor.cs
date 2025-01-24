using System.Collections;
using System.Collections.Generic;
using Architecture;
using Assets.Resources.LightSystem.Scripts;
using Assets.Resources.MapSystem.Scripts;
using Assets.Scripts.LabyrinthGenerator;
using CoroutineManager;
using MyTimer;
using UnityEngine;

public class LightInteractor : Interactor
{
    private Light light;
    private LightConfig lightConfig;

    private readonly RoomType currentRoom = RoomType.UnTyped;

    private const int LIGHT_MAIN_INDEX = 0;
    private const int LIGHT_EMERGENCY_INDEX = 1;
    private const int LIGHT_BLINKING_INDEX = 2;

    private Timer switchTimer;
    private Coroutine blinkingCorroutine;

    public override void Initialize()
    {
        base.Initialize();

        lightConfig = new();
        switchTimer = new();
    }

    public override void OnCreate()
    {
        base.OnCreate();

        light = ResourceLoader.Load<Light>("LightSystem/Prefabs/Directional Light");        
    }

    public override void OnStart()
    {
        base.OnStart();
    }


    public void LoadRoomLightSettings(RoomLight roomLight)
    {
        StopBlinking();

        if (currentRoom != roomLight.type)
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

        if (roomLight.isGeneralLighting)
        {
            roomLight.SetLightMap(LIGHT_MAIN_INDEX);
        }
        else if(roomLight.isEmergencyLighting)
        {
            if (roomLight.isEmergencyBlinking)
            {
                blinkingCorroutine = BlinkingAsync(roomLight);
            }
            else
            {
                roomLight.SetLightMap(LIGHT_EMERGENCY_INDEX);
            }
        }
    }


    private Coroutine BlinkingAsync(RoomLight roomLight)
    {
        return Coroutines.StartRoutine(BlinkingRoutine(roomLight));
    }
    private IEnumerator BlinkingRoutine(RoomLight roomLight)
    {
        Light blinkingLight = roomLight.blinkingLight;
        switchTimer.OnStoped += () =>
        {
            blinkingLight.enabled = !blinkingLight.enabled;
            roomLight.SetLightMap(blinkingLight.enabled ? LIGHT_EMERGENCY_INDEX : LIGHT_BLINKING_INDEX);

            if (blinkingLight.enabled)
            {
                blinkingLight.intensity = Random.Range(0.5f, 1.5f);
            }
        };

        while (true)
        {
            if (!switchTimer.IsStarted)
            {
                RestartTimer();
            }

            yield return null;
        }

        void RestartTimer() => switchTimer.Start(blinkingLight.enabled ? Mathf.Pow(Random.Range(1.5f, 0.2f), 2) : 0.1f);
    }

    private void StopBlinking()
    {
        if(blinkingCorroutine != null)
        {
            switchTimer.Reset();
            switchTimer = new();

            Coroutines.StopRoutine(blinkingCorroutine);
        }        
    }
}
