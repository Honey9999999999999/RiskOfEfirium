using System.Collections.Generic;
using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

namespace Assets.Resources.MapSystem.Scripts
{
    public class RoomLight : MonoBehaviour
    {
        [Header("Lightmap Settings")]
        public RoomType type;
        public int indexLigtMapOffset;

        public Color32 ambientColor;

        public bool isGeneralLighting;
        public bool isEmergencyLighting;
        public bool isEmergencyBlinking;

        public List<Light> emergencyLights;
        public Light blinkingLight;

        public MeshRenderer targetMesh;


        private void OnEnable()
        {
            if (!Game.sceneManager.isLoading)
            {
                LoadSettings();
            }
        }
        private void LoadSettings()
        {
            Game.GetInteractor<LightInteractor>().LoadRoomLightSettings(this);
        }

        public void SetLightMap(int index)
        {
            targetMesh.lightmapIndex = index + indexLigtMapOffset;
        }
    }
}