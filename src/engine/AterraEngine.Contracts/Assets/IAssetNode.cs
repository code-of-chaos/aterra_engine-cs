﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Contracts.Assets;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IAssetNode : IEnumerable<IAsset> {
    public IAsset? Asset { get; set; }
    public List<IAssetNode> Children { get; }
    public IEnumerable<IAsset> Flat();
    public int Count();
    IEnumerable<IAsset> CachedFlat { get; }
}