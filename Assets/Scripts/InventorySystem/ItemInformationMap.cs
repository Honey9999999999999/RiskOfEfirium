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
                "Sprites/UI/Icons/Lines/iconDNA"
            ),
            [ItemNames.MechanicalResources] = new
            (
                ItemNames.MechanicalResources,
                Tier.Common,
                "Механические части",
                "Шестеренки, пружины, и прочие железки",
                "Sprites/UI/Icons/Lines/iconGear"
            ),
            [ItemNames.ElectricResources] = new
            (
                ItemNames.ElectricResources,
                Tier.Common,
                "Электрические компоненты",
                "Всякие микроконтроллеры, резисторы, транзисторы и прочая электроника",
                "Sprites/UI/Icons/Lines/iconPlate"
            ),
            [ItemNames.ImprovedLaserBattery] = new
            (
                ItemNames.ImprovedLaserBattery,
                Tier.Uncommon,
                "Улучшенная энергетическая батарея",
                "Увеличивает количество выстрелов после перезарядки",
                "Sprites/UI/Icons/Lines/iconCharge"
            ),
            [ItemNames.SyneticMuscles] = new
            (
                ItemNames.SyneticMuscles,
                Tier.Uncommon,
                "Синтетические мышцы",
                "Увеличивает скорость передвижения",
                "Sprites/UI/Icons/Lines/iconMovementSpeed"
            ),
            [ItemNames.Thermostat] = new
            (
                ItemNames.Thermostat,
                Tier.Uncommon,
                "Терморегулятор",
                "Увеличивает скорострельность",
                "Sprites/UI/Icons/Lines/iconRateOfFire"
            ),
            [ItemNames.ChargingChamberCapacitor] = new
            (
                ItemNames.ChargingChamberCapacitor,
                Tier.Uncommon,
                "Конденсатор зарядной камеры",
                "Увеличивает урон",
                "Sprites/UI/Icons/Lines/iconDamage"
            )
        };

        public ItemInfo GetInfo(ItemNames name) => _itemInfoMap[name];
    }
}
