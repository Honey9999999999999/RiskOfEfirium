using System.Collections.Generic;

namespace UI.Cursor.Configs
{
    public class CursorSimpleConfig : CursorConfig
    {
        public override Dictionary<CursorMode, string> cursorsMap => new()
        {
            [CursorMode.Standart] = "Sprites/UI/Cursor/Standart",
            [CursorMode.Battle] = "Sprites/UI/Cursor/Battle"
        };
    }
}
