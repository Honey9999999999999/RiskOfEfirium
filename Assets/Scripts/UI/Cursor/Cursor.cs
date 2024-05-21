using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Cursor
{
    public class Cursor
    {
        private Dictionary<CursorMode, Texture2D> _cursorsMap;

        public Cursor(CursorConfig config)
        {
            _cursorsMap = new();

            foreach (var mode in config.cursorsMap.Keys.ToArray())
            {
                _cursorsMap.Add(mode, config.GetTexture2D(mode));
            }
        }

        public void SetMode(CursorMode mode)
        {
            UnityEngine.Cursor.SetCursor(_cursorsMap[mode], new Vector2(_cursorsMap[mode].width / 2, _cursorsMap[mode].height / 2), UnityEngine.CursorMode.Auto);
        }
    }
}
