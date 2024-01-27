﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Types;
using Raylib_cs;

namespace AterraEngine.Contracts.Assets;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ILevel : IEngineAsset{
    public IAssetNode Assets { get; set; }
    public ICamera2D Camera2D { get; set; }
    public Color BufferBackground { get; }
}