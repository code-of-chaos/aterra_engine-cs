﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Types;

namespace AterraEngine.Interfaces.Assets.Lib;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ILevel2D : IAsset {
    public List<EngineAssetId> Assets { get; set; }
    
    public void ResolveAssetIds();
    public void CollideAll();
}