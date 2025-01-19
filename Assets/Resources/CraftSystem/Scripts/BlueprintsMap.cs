using System.Collections.Generic;
using System.Linq;
using Architecture;
using Assets.Scripts.InventorySystem;

namespace Assets.Scripts.CraftSystem
{
    public class BlueprintsMap
    {
        private readonly Dictionary<ItemNames, Blueprint> blueprintsMap;

        public BlueprintsMap()
        {
            ItemInformationMap infoMap = Game.GetInteractor<InventorySystemInteractor>().ItemInformationCard;

            blueprintsMap = new()
            {
                [ItemNames.ChargingChamberCapacitor] = new Blueprint(
                    WorkBenchType.Armory,
                    infoMap.GetInfo(ItemNames.ChargingChamberCapacitor),
                    new()
                    {
                        [ItemNames.MechanicalResources] = 3,
                        [ItemNames.ElectricResources] = 2
                    }
                ),
                [ItemNames.ImprovedLaserBattery] = new Blueprint(
                    WorkBenchType.Armory,
                    infoMap.GetInfo(ItemNames.ImprovedLaserBattery),
                    new()
                    {
                        [ItemNames.AlienResources] = 1,
                        [ItemNames.MechanicalResources] = 2,
                        [ItemNames.ElectricResources] = 1
                    }
                ),                
                [ItemNames.Thermostat] = new Blueprint(
                    WorkBenchType.Armory,
                    infoMap.GetInfo(ItemNames.Thermostat),
                    new()
                    {
                        [ItemNames.MechanicalResources] = 2,
                        [ItemNames.ElectricResources] = 2
                    }
                ),


                [ItemNames.SyneticMuscles] = new Blueprint(
                    WorkBenchType.Medical,
                    infoMap.GetInfo(ItemNames.SyneticMuscles),
                    new()
                    {
                        [ItemNames.AlienResources] = 3,
                        [ItemNames.MechanicalResources] = 1,
                        [ItemNames.ElectricResources] = 1
                    }
                ),
                [ItemNames.Mutagens] = new Blueprint(
                    WorkBenchType.Medical,
                    infoMap.GetInfo(ItemNames.Mutagens),
                    new()
                    {
                        [ItemNames.AlienResources] = 4
                    }
                ),
                [ItemNames.ModifiedStemCells] = new Blueprint(
                    WorkBenchType.Medical,
                    infoMap.GetInfo(ItemNames.ModifiedStemCells),
                    new()
                    {
                        [ItemNames.AlienResources] = 2,
                        [ItemNames.ElectricResources] = 1,
                    }
                ),


                [ItemNames.LightCapacitor] = new Blueprint(
                    WorkBenchType.Engineer,
                    infoMap.GetInfo(ItemNames.LightCapacitor),
                    new()
                    {
                        [ItemNames.MechanicalResources] = 1,
                        [ItemNames.ElectricResources] = 3
                    }
                ),
                [ItemNames.ArmoredPads] = new Blueprint(
                    WorkBenchType.Engineer,
                    infoMap.GetInfo(ItemNames.ArmoredPads),
                    new()
                    {
                        [ItemNames.AlienResources] = 1,
                        [ItemNames.MechanicalResources] = 3,
                        [ItemNames.ElectricResources] = 1
                    }
                )
                { }
            };
        }

        public List<Blueprint> GetBlueprints() => blueprintsMap.Values.ToList();
        public Blueprint GetBlueprint(ItemNames name) => blueprintsMap[name];
    }
}
