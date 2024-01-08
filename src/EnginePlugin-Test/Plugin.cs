﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Plugin;

namespace EnginePlugin_Test;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Plugin : EnginePlugin {
    public override void ManagedInitialize(string idPrefix) {
        base.ManagedInitialize(idPrefix);
        
        Console.WriteLine("Hello there form the plugin");
        
    }
}