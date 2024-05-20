using Assets.Scripts.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Cursor
{
    public abstract class CursorConfig
    {
        public abstract Dictionary<CursorMode, string> cursorsMap { get; }

        public Texture2D GetTexture2D(CursorMode mode)
        {
            return Instantiater.Instantiate<Texture2D>(cursorsMap[mode]);
        }
    }
}
