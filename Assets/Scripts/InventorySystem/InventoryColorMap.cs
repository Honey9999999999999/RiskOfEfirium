using UnityEngine;

namespace Assets.Scripts.InventorySystem
{

    [CreateAssetMenu(fileName = "InventoryColors", menuName = "ScriptableObjects/InventoryColors")]
    public class InventoryColorMap : ScriptableObject
    {
        public Color32 commonColor;
        public Color32 uncommonColor;
        public Color32 rareColor;
        public Color32 legendaryColor;

        public Color32 GetColorFor(Tier tier)
        {
            return tier switch
            {
                Tier.Common => commonColor,
                Tier.Uncommon => uncommonColor,
                Tier.Rare => rareColor,
                Tier.Legendary => legendaryColor,
                _ => commonColor
            };
        }
    }
}
