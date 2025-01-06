using Architecture;
using Assets.Scripts.Tools;
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
            _stateMachine.ClearStates();

            TSkinConfig config = new();

            _stateMachine.AddState(new CursorSimpleState(_stateMachine, ResourceLoader.Load<Texture2D>(config.cursorsMap[CursorMode.Standart])));
            _stateMachine.AddState(new CursorBattleState(_stateMachine, ResourceLoader.Load<Texture2D>(config.cursorsMap[CursorMode.Battle])));

            _stateMachine.EnterIn<CursorSimpleState>();
        }
    }
}
