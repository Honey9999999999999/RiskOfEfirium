using System.Collections.Generic;
using UnityEngine;

namespace UICursor
{
    public abstract class SkinPresetConfig
    {
        public abstract Dictionary<CursorMode, string> cursorsMap { get; }

        public Texture2D GetTexture2D(CursorMode mode)
        {
            return ResourceLoader.Load<Texture2D>(cursorsMap[mode]);
        }
    }
}
