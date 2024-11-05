namespace Assets.Scripts.InventorySystem
{
    public class ElectricResource : Item
    {
        public override NamesOfDrop Name => NamesOfDrop.ElectricResources;

        public override void Effect() { }
        public override void ReverseEffect() { }
    }
}
