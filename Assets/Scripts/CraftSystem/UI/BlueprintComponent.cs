using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CraftSystem
{
    [RequireComponent(typeof(Image))]
    public class BlueprintComponent : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _counter;

        public void SetComponent(Sprite sprite, int count)
        {
            _icon.sprite = sprite;
            _counter.text = count.ToString();
        }
    }
}
