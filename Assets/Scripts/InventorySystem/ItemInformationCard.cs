using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class ItemInformationCard
    {
        private readonly Dictionary<NamesOfDrop, ItemInfo> _itemInfoMap = new()
        {
            [NamesOfDrop.AlienResources] = new
            (
                "Часть чужого", 
                "Добытая прямиком из инопланетной формы жизни, " +
                "эта субъстанция способна быть одновременно как и невероятно мягкой, " +
                "так и нев ероятно твердой"
            ),
            [NamesOfDrop.MechanicalResources] = new
            (
                "Механические части", 
                "Шестеренки, пружины, и прочие железки"
            ),
            [NamesOfDrop.ElectricResources] = new
            (
                "Электрические компоненты", 
                "Всякие микроконтроллеры, резисторы, транзисторы ипрочая электроника"
            ),
            [NamesOfDrop.ImprovedLaserBattery] = new
            (
                "Улучшенная энергетическая батарея",
                "Увеличивает количество выстрелов после перезарядки"
            ),
            [NamesOfDrop.SyneticMuscles] = new
            (
                "Синтетические мышцы", 
                "Увеличивает скорость передвижения"
            ),
            [NamesOfDrop.Thermostat] = new
            (
                "Терморегулятор", 
                "Увеличивает скорострельность"
            ),
        };

        public ItemInfo GetInfo(NamesOfDrop name) => _itemInfoMap[name];
    }
}
