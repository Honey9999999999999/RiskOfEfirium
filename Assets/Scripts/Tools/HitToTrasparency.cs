using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tools
{
    [RequireComponent(typeof(Image))]
    public class HitToTrasparency : MonoBehaviour
    {
        public float alpha = 1;

        public void Awake()
        {
            GetComponent<Image>().alphaHitTestMinimumThreshold = alpha;
        }
    }
}
