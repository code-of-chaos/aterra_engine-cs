﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Contracts.Components;
using AterraEngine.Contracts.ECS;

namespace AterraEngine.Contracts.Assets;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IAsset : IEntity {
    ITransform2DComponent Transform { get; }
    IMovement2DComponent Movement { get; }
}