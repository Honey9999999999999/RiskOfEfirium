namespace Assets.Scripts.InventorySystem
{
    public sealed class AlienResource : Item
    {
        public override NamesOfDrop Name => NamesOfDrop.AlienResources;

        public override void Effect() { }
        public override void ReverseEffect() { }
    }
}
