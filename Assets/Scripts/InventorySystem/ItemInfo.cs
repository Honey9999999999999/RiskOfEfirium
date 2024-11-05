namespace Assets.Scripts.InventorySystem
{
    public class ItemInfo
    {
        public Tier Tier { get; }
        public string Name { get; }
        public string Description { get; }
        public string IconPath { get; }

        public ItemInfo(Tier tier, string name, string desctiption, string iconPath)
        {
            Tier = tier;
            Name = name;
            Description = desctiption;
            IconPath = iconPath;
        }
    }
}
