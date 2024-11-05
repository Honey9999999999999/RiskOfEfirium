using Architecture;
using Assets.Scripts.Movement;

namespace Assets.Scripts.InventorySystem
{
    internal class SyneticMuscles : Item
    {
        private const float _procent = 0.25f;

        public override NamesOfDrop Name => NamesOfDrop.SyneticMuscles;

        public override void Effect()
        {
            MovePlayerFSMInstance fSMInstance = Game.GetInteractor<PlayerInteractor>().player.GetMoveInstance();
            float baseSpeed = fSMInstance.GetBaseSpeed();
            fSMInstance.SetSpeed(baseSpeed + baseSpeed * amount * _procent);
        }

        public override void ReverseEffect()
        {
            Effect();
        }
    }
}
