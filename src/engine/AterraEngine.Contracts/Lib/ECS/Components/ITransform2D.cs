﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Numerics;
using Raylib_cs;
namespace AterraEngine.Contracts.Lib.ECS.Components;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------

public interface ITransform2D {
    float Rotation { get; set; }
    Vector2 Position { get; set; }
    Vector2 Scale { get; set; }
    Matrix3x2 TransformationMatrix { get; }
}