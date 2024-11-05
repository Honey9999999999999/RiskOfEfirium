namespace Assets.Scripts.InventorySystem
{
    public class MechanicalResource : Item
    {
        public override NamesOfDrop Name => NamesOfDrop.MechanicalResources;

        public override void Effect() { }
        public override void ReverseEffect() { }
    }
}
