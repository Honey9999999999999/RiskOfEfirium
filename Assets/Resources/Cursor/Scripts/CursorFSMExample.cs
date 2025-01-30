using Assets.Scripts.UI.CursorGame;
using Assets.Scripts.UI.CursorGame.States;
using FSM;
using UICursor.Configs;
using UnityEngine;

namespace UICursor
{
    public class CursorFSMExample : FSMExample<CursorFSM, CursorState>
    {
        private void Start()
        {
            ChangeSkinPreset<SkinPresetSimpleConfig>();
        }

        public void ChangeSkinPreset<TSkinConfig>() where TSkinConfig : SkinPresetConfig, new()
        {
            stateMachine.ClearStates();

            TSkinConfig config = new();

            stateMachine.AddState(new CursorSimpleState(stateMachine, ResourceLoader.Load<Texture2D>(config.cursorsMap[CursorMode.Standart])));
            stateMachine.AddState(new CursorBattleState(stateMachine, ResourceLoader.Load<Texture2D>(config.cursorsMap[CursorMode.Battle])));
            stateMachine.AddState(new CursorMenuState(stateMachine, ResourceLoader.Load<Texture2D>(config.cursorsMap[CursorMode.Standart])));

            stateMachine.EnterIn<CursorSimpleState>();
        }
    }
}
