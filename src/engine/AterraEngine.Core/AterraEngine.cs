﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Contracts;
using AterraEngine.Core.ServicesFramework;
using Serilog;

namespace AterraEngine.Core;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class AterraEngine : IAterraEngine {
    protected ILogger Logger = DefaultServices.GetLogger();
}