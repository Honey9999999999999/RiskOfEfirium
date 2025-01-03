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
                "Sprites/UI/Icons/Lines/iconDNA"
            ),
            [NamesOfDrop.MechanicalResources] = new
            (
                Tier.Common,
                "Механические части",
                "Шестеренки, пружины, и прочие железки",
                "Sprites/UI/Icons/Lines/iconGear"
            ),
            [NamesOfDrop.ElectricResources] = new
            (
                Tier.Common,
                "Электрические компоненты",
                "Всякие микроконтроллеры, резисторы, транзисторы ипрочая электроника",
                "Sprites/UI/Icons/Lines/iconPlate"
            ),
            [NamesOfDrop.ImprovedLaserBattery] = new
            (
                Tier.Uncommon,
                "Улучшенная энергетическая батарея",
                "Увеличивает количество выстрелов после перезарядки",
                "Sprites/UI/Icons/Lines/iconCharge"
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
                "Sprites/UI/Icons/Lines/iconRateOfFire"
            ),
        };

        public ItemInfo GetInfo(NamesOfDrop name) => _itemInfoMap[name];
    }
}
