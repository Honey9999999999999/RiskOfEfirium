using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

namespace Assets.Resources.MapSystem.Scripts
{
    public class RoomLight : MonoBehaviour
    {
        [Header("Lightmap Settings")]
        public RoomType type;
        public int lightmapIndex;      // Индекс Lightmap
        public bool isGeneralLighting;
        public Color32 ambientColor;

        public GameObject targetMesh;  // Целевой объект для применения Lightmap


        private void OnEnable()
        {
            ApplyLightmap();
        }
        private void ApplyLightmap()
        {
            if (targetMesh == null)
            {
                Debug.LogError("Целевой объект не указан!");
                return;
            }

            // Проверяем наличие MeshRenderer
            if (!targetMesh.TryGetComponent<MeshRenderer>(out var renderer))
            {
                Debug.LogError("MeshRenderer не найден на целевом объекте!");
                return;
            }

            Game.GetInteractor<LightInteractor>().LoadRoomLightSetings(this);

            // Назначаем Lightmap Index
            renderer.lightmapIndex = lightmapIndex;

            Debug.Log("Lightmap успешно применён на объект.");
        }
    }
}