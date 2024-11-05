namespace Assets.Scripts.InventorySystem
{
    public class ItemInfo
    {
        public string Name { get; }
        public string Description { get; }

        public ItemInfo(string name, string desctiption)
        {
            Name = name;
            Description = desctiption;
        }
    }
}
