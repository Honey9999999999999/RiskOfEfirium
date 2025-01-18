namespace Assets.Scripts.InventorySystem
{
    public class ItemInfo
    {
        public ItemNames ServiceName { get; }
        public Tier Tier { get; }
        public string Name { get; }        
        public string Description { get; }
        public string IconPath { get; }

        public ItemInfo(ItemNames serviceName, Tier tier, string name, string desctiption, string iconPath)
        {
            ServiceName = serviceName;
            Tier = tier;
            Name = name;            
            Description = desctiption;
            IconPath = iconPath;
        }
    }
}
