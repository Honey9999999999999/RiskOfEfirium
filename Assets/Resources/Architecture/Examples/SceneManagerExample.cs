namespace Architecture
{
    public class SceneManagerExample : SceneManagerBase
    {
        public override void InitSceneConfigMap()
        {
            _sceneConfigMap[SceneConfigExample.SCENE_NAME] = new SceneConfigExample();
        }
    }
}
