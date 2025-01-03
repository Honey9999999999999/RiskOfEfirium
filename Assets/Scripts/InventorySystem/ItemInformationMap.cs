using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class ItemInformationMap
    {
        private readonly Dictionary<NamesOfDrop, ItemInfo> _itemInfoMap = new()
        {
            [NamesOfDrop.AlienResources] = new
            (
                Tier.Common,
                "Часть чужого",
                "Добытая прямиком из инопланетной формы жизни, " +
                "эта субъстанция способна быть одновременно как и невероятно мягкой, " +
                "так и нев ероятно твердой",
                "Sprites/Circle"
            ),
            [NamesOfDrop.MechanicalResources] = new
            (
                Tier.Common,
                "Механические части",
                "Шестеренки, пружины, и прочие железки",
                "Sprites/Circle"
            ),
            [NamesOfDrop.ElectricResources] = new
            (
                Tier.Common,
                "Электрические компоненты",
                "Всякие микроконтроллеры, резисторы, транзисторы ипрочая электроника",
                "Sprites/Circle"
            ),
            [NamesOfDrop.ImprovedLaserBattery] = new
            (
                Tier.Uncommon,
                "Улучшенная энергетическая батарея",
                "Увеличивает количество выстрелов после перезарядки",
                "Sprites/IsometricDiamond"
            ),
            [NamesOfDrop.SyneticMuscles] = new
            (
                Tier.Uncommon,
                "Синтетические мышцы",
                "Увеличивает скорость передвижения",
                "Sprites/IsometricDiamond"
            ),
            [NamesOfDrop.Thermostat] = new
            (
                Tier.Uncommon,
                "Терморегулятор",
                "Увеличивает скорострельность",
                "Sprites/IsometricDiamond"
            ),
        };

        public ItemInfo GetInfo(NamesOfDrop name) => _itemInfoMap[name];
    }
}
