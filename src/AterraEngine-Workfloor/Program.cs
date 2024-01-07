﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Ansi;
using ArgsParser;
namespace AterraEngine_Workfloor;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ArgOptions {
    [ArgsFlag('e', "editor")] public bool RunEditor { get; set; } = false;
}

// ReSharper disable once UnusedType.Global
static class Program {
    public static void Main(string[] args) {
        ArgOptions argOptions = new PropertyParser<ArgOptions>().Parse(args);

        
    }
}