﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Atlases;
using AterraEngine.Interfaces.Plugin;
using AterraEngine.Plugins;

using EnginePlugin_Test.Data;
namespace EnginePlugin_Test;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Plugin : AEnginePlugin {
    public override string NameReadable => "Test Plugin";
    
    public override IEnginePluginServices PluginServices() => new PluginServices();
    public override IEnginePluginTextures PluginTextures(ITexture2DAtlas texture2DAtlas) => new PluginTextures(texture2DAtlas);
    public override IEnginePluginAssets   PluginAssets(IAssetAtlas assetAtlas) => new PluginAssets(assetAtlas).DefineConfig(IdPrefix);
    
}