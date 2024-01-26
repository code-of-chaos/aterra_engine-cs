﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using AterraEngine.Contracts.Assets;
using AterraEngine.Contracts.Atlases;
using AterraEngine.Types;

namespace AterraEngine.Atlases;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class AssetAtlas: IAssetAtlas {
    private readonly Dictionary<EngineAssetId, IAsset> _dictionary = new();

    public bool TryGetAsset(EngineAssetId assetId, [NotNullWhen(true)] out IAsset? asset) => TryGetAsset<IAsset>(assetId, out asset);
    public bool TryGetAsset<T>(EngineAssetId assetId, [NotNullWhen(true)] out T? asset) where T : IAsset {
        if (_dictionary.TryGetValue(assetId, out IAsset? tempAsset) && tempAsset is T value) {
            asset = value;
            return true;
        }

        asset = default;
        return false;
    }

    public bool TryRegisterAsset(IAsset asset) {
        return _dictionary.TryAdd(asset.Id, asset);
    }

    public IReadOnlyDictionary<EngineAssetId, ILevel> GetAllLevels() {
        return _dictionary
            .Where(pair => pair.Value is ILevel)
            .ToImmutableDictionary(pair => pair.Key, pair => (ILevel)pair.Value);
    }
    
    public bool TryGetLevel<T>(EngineAssetId assetId, [NotNullWhen(true)] out T? asset) where T : ILevel {
        if (GetAllLevels().TryGetValue(assetId, out ILevel? tempAsset) && tempAsset is T value) {
            asset = value;
            return true;
        }

        asset = default;
        return false;
    }
}