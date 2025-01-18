using Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CraftSystem.UI
{
    [RequireComponent(typeof(Image))]
    public class LightsControl : MonoBehaviour
    {
        [SerializeField] Sprite goodLights;
        [SerializeField] Sprite neutralLights;
        [SerializeField] Sprite badLights;

        private Image image;

        public void Start()
        {
            image = GetComponent<Image>();
        }

        public void OnEnable()
        {
            ItemCreator.OnCrafted += SetState;
        }
        public void OnDisable()
        {
            ItemCreator.OnCrafted -= SetState;
        }

        public void SetState()
        {
            if (Game.GetInteractor<CraftSystemInteractor>().Crafter.IsContaintsAllComponents(WorkBenchWindow.currentBlueprint))
            {
                image.sprite = goodLights;
            }
            else
            {
                image.sprite = badLights;
            }
        }

        public void SetNeutral() => GetComponent<Image>().sprite = neutralLights;
    }
}
