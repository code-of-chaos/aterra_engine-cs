﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Text.RegularExpressions;

namespace AterraEngine_lib.structs;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public struct EngineAssetId(PluginId pluginId, int value) : IComparable<EngineAssetId> {
    public PluginId PluginId { get; } = pluginId;
    public int Id { get; } = value;

    // -----------------------------------------------------------------------------------------------------------------
    // Constructors
    // -----------------------------------------------------------------------------------------------------------------

    // -----------------------------------------------------------------------------------------------------------------
    // Constructors
    // -----------------------------------------------------------------------------------------------------------------
    public override string ToString() {
        return $"{PluginId.ToString().PadLeft(4, '0')}{Id.ToString("X").PadLeft(8, '0')}";
    }

    public int CompareTo(EngineAssetId other) {
        var pluginIdComparison = PluginId.CompareTo(other.PluginId);
        return pluginIdComparison != 0 
            ? pluginIdComparison 
            : Id.CompareTo(other.Id);
    }
}