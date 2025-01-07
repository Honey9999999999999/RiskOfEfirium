using System.Collections.Generic;

namespace UICursor.Configs
{
    public class SkinPresetSimpleConfig : SkinPresetConfig
    {
        public override Dictionary<CursorMode, string> cursorsMap => new()
        {
            [CursorMode.Standart] = "Sprites/UI/Cursor/Standart",
            [CursorMode.Battle] = "Sprites/UI/Cursor/Battle",
            [CursorMode.Vision] = "Sprites/UI/Cursor/Standart"
        };
    }
}
