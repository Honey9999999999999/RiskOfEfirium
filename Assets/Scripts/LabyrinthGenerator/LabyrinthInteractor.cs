using Architecture;
using UnityEngine;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class LabyrinthInteractor : Interactor
    {
        public LevelMap levelMap { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            Debug.Log("Labyrinth Initialized!");
        }

        public override void OnCreate()
        {
            base.OnCreate();

            levelMap = new(new MapGeneratorConfigExample());
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
