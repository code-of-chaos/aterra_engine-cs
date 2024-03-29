﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Contracts.Components;
namespace AterraEngine.Contracts.ECS.EntityTypes;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ITransformEntity : IEntity {
    public ITransform2DComponent Transform { get; }
}