﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using OldAterraEngine.Contracts.DTOs.Assets;
using OldAterraEngine.Contracts.Assets;

namespace OldAterraEngine.Contracts.Factories;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ILevelFactory {
    public ILevel? CreateLevel(LevelDto levelDto);
}