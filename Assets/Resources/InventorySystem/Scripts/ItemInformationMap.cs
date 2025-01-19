using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class ItemInformationMap
    {
        private readonly Dictionary<ItemNames, ItemInfo> _itemInfoMap = new()
        {
            [ItemNames.AlienResources] = new
            (
                ItemNames.AlienResources,
                Tier.Common,
                "Часть чужого",
                "Добытая прямиком из инопланетной формы жизни, " +
                "эта субъстанция способна быть одновременно как и невероятно мягкой, " +
                "так и нев ероятно твердой",
                "InventorySystem/Sprites/Icons/Lines/iconDNA"
            ),
            [ItemNames.MechanicalResources] = new
            (
                ItemNames.MechanicalResources,
                Tier.Common,
                "Механические части",
                "Шестеренки, пружины, и прочие железки",
                "InventorySystem/Sprites/Icons/Lines/iconGear"
            ),
            [ItemNames.ElectricResources] = new
            (
                ItemNames.ElectricResources,
                Tier.Common,
                "Электрические компоненты",
                "Всякие микроконтроллеры, резисторы, транзисторы и прочая электроника",
                "InventorySystem/Sprites/Icons/Lines/iconPlate"
            ),
            [ItemNames.ImprovedLaserBattery] = new
            (
                ItemNames.ImprovedLaserBattery,
                Tier.Uncommon,
                "Улучшенная энергетическая батарея",
                "Увеличивает количество выстрелов после перезарядки",
                "InventorySystem/Sprites/Icons/Lines/iconCharge"
            ),
            [ItemNames.SyneticMuscles] = new
            (
                ItemNames.SyneticMuscles,
                Tier.Uncommon,
                "Синтетические мышцы",
                "Увеличивает скорость передвижения",
                "InventorySystem/Sprites/Icons/Lines/iconMovementSpeed"
            ),
            [ItemNames.Thermostat] = new
            (
                ItemNames.Thermostat,
                Tier.Uncommon,
                "Терморегулятор",
                "Увеличивает скорострельность",
                "InventorySystem/Sprites/Icons/Lines/iconRateOfFire"
            ),
            [ItemNames.ChargingChamberCapacitor] = new
            (
                ItemNames.ChargingChamberCapacitor,
                Tier.Uncommon,
                "Конденсатор зарядной камеры",
                "Увеличивает урон",
                "InventorySystem/Sprites/Icons/Lines/iconDamage"
            )
        };

        public ItemInfo GetInfo(ItemNames name) => _itemInfoMap[name];
    }
}
