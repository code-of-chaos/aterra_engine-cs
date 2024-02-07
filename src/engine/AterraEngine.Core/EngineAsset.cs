﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Core.Types;

namespace AterraEngine.Core;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------

public class EngineAsset(EngineAssetId id, string? internalName=null) {
    public EngineAssetId Id { get; } = id;
    public string? InternalName { get; } = internalName;
}