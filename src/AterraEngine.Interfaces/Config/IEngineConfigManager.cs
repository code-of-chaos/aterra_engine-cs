﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Interfaces.Config;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineConfigManager<T> where T :  IEngineConfig {
    public T LoadConfigFile(string filePath);
    public bool TrySaveConfig(T config,string outputPath);
    
}