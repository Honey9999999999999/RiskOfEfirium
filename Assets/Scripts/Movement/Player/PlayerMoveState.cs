using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Tools;
using FSM;

namespace Assets.Scripts.Movement
{
    public class PlayerMoveState : MoveState<PlayerMoveState, Player, PlayerController>
    {
        public PlayerMoveState(FinalStateMachine<PlayerMoveState> stateMachine, Player entity, ShellValue<float> speed) : base(stateMachine, entity, speed)
        {
        }
    }
}
