﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Contracts.Core.PluginFramework;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IPluginFactory {
   bool TryLoadPluginFromType(Type objectType);
   void LoadPluginsFromDLLFilePaths(IEnumerable<string> filePaths, bool throwOnFail);
}