﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Numerics;
using AterraEngine.Contracts.Assets;

namespace AterraEngine.Contracts.Components;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IDrawDebug2DComponent : IComponent {
    public void Draw(Vector2 pos, float rot, Vector2 origin, Vector2 size, Vector2 worldToScreenSpace);
}