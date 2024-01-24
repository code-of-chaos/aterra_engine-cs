﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Atlases;

namespace AterraEngine.Interfaces.Plugin;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEnginePluginTextures {
    public ITexture2DAtlas Texture2DAtlas { get; }
    public void Define();
}