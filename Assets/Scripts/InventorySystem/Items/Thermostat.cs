using Architecture;
namespace Assets.Scripts.InventorySystem.Items
{
    public class Thermostat : Item
    {
        private readonly Gun _gun;
        private const float _procent = 0.1f;

        public override NamesOfDrop Name => NamesOfDrop.Thermostat;

        public Thermostat()
        {
            _gun = Game.GetInteractor<PlayerInteractor>().player.GetBattleFSM().GetGun();
        }

        public override void Effect()
        {
            _gun.SetRateFire(_gun.StockRateFire - _gun.StockRateFire * amount * _procent);
        }

        public override void ReverseEffect()
        {
            Effect();
        }
    }
}
