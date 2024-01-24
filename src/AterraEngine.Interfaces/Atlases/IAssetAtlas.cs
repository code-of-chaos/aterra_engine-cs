﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Diagnostics.CodeAnalysis;
using AterraEngine.Interfaces.Actors;
using AterraEngine.Types;
namespace AterraEngine.Interfaces.Atlases;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IAssetAtlas {

    public bool TryGetAsset(EngineAssetId assetId, [MaybeNullWhen(false)] out IAsset asset);
    public bool TryGetAsset<T>(EngineAssetId assetId, [MaybeNullWhen(false)] out T asset) where T : IAsset?;
    
    public bool TryRegisterAsset(IAsset asset);

}