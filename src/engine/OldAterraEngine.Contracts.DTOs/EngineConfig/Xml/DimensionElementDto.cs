﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Xml.Serialization;

namespace OldAterraEngine.Contracts.DTOs.EngineConfig.Xml;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public record DimensionElementDto {
    [XmlAttribute("width")] public int Width;
    [XmlAttribute("height")] public int Height;
}