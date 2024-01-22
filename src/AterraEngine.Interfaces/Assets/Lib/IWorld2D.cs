﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Component;
using AterraEngine.Types;

namespace AterraEngine.Interfaces.Assets.Lib;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IWorld2D : IDrawableComponent {
    public ILevel2D Level2D { get; set; }
    public EngineAssetId PlayerId { get; set; }
}