﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Contracts.EngineFactory.Config;
using AterraEngine.DTO.EngineConfig;

namespace AterraEngine.EngineFactory.Config;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineConfigFactory<T>:IEngineConfigFactory<T> where T : EngineConfigDto {
    private readonly EngineConfigParser<T> _configParser = new();
    
    public bool TryLoadConfigFile(string filePath, out T? engineConfig) {
        return _configParser.TryDeserializeFromFile(filePath, out engineConfig);
    }

    public bool TrySaveConfig(T config, string outputPath) {
        // Serialize the config object to XML
        return _configParser.TrySerializeToFile(config, outputPath);
    }

}