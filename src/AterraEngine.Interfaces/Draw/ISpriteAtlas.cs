﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Raylib_cs;

namespace AterraEngine.Interfaces.Draw;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ISpriteAtlas {
    public bool TryAddSprite<T>(string spriteName, string textureName, Rectangle? box =null) where T: ISprite;
    public bool TryAddSprite<T>(string spriteName, string textureName, out T? sprite, Rectangle? box = null) where T : ISprite;
    public bool TryGetSprite<T>(string spriteName, out T? sprite) where T : ISprite;
}