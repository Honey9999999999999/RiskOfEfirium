using Architecture;
using System;

namespace Assets.Scripts.InventorySystem.Items
{
    internal class ImprovedLaserBattery : Item
    {
        private readonly Gun _gun;
        private const float _procent = 0.15f;

        public override NamesOfDrop Name => NamesOfDrop.ImprovedLaserBattery;

        public ImprovedLaserBattery()
        {
            _gun = Game.GetInteractor<PlayerInteractor>().player.GetBattleFSM().GetGun();
        }

        public override void Effect()
        {
            int count = _gun.StockMaxAmmo;

            for (int i = 0; i < amount; i++)
            {
                count += (int)MathF.Ceiling(count * _procent);
            }

            _gun.SetAmmoCount(count);
        }

        public override void ReverseEffect()
        {
            Effect();
        }
    }
}
