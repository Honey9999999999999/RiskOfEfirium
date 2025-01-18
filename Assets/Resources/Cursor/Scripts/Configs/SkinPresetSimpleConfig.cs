using System.Collections.Generic;

namespace UICursor.Configs
{
    public class SkinPresetSimpleConfig : SkinPresetConfig
    {
        public override Dictionary<CursorMode, string> cursorsMap => new()
        {
            [CursorMode.Standart] = "Cursor/Sprites/Standart",
            [CursorMode.Battle] = "Cursor/Sprites/Battle",
            [CursorMode.Vision] = "Cursor/Sprites/Standart"
        };
    }
}
