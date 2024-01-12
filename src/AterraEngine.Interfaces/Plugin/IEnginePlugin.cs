﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine_lib.structs;
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine.Interfaces.Plugin;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEnginePlugin {
    public PluginId IdPrefix { get;}
    public IEnginePlugin DefineConfig(PluginId idPrefix);
    public IServiceCollection DefineServices(IServiceCollection serviceCollection);
    public IEnginePlugin DefineData(); // static data (like sprites....)
}