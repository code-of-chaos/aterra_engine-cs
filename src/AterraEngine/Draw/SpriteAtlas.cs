﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Draw;
using AterraEngine.Services;
using Raylib_cs;

namespace AterraEngine.Draw;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class SpriteAtlas(ITextureAtlas textureAtlas) : ISpriteAtlas {
    private readonly Dictionary<string, ISprite> _sprites = new();

    public bool TryAddSprite<T>(string spriteName, string textureName, Rectangle? box =null) where T:ISprite {
        return TryAddSprite<T>(spriteName, textureName, out _, box);
    }

    public bool TryAddSprite<T>(string spriteName, string textureName, out T? sprite, Rectangle? box = null) where T : ISprite {
        sprite = EngineServices.GetService<T>();
        
        if (!textureAtlas.TryGetTexture(textureName, out var texture) || texture == null) {
            return false;
        }
        
        sprite.Texture = (Texture2D)texture;
        sprite.SelectionBox = box ?? new Rectangle(0,0, sprite.Texture.Width,sprite.Texture.Height);
        
        return  _sprites.TryAdd(spriteName, sprite);
    }

    public bool TryGetSprite<T>(string spriteName, out T? sprite) where T : ISprite {
        sprite = default;
        if (!_sprites.TryGetValue(spriteName, out var tempSprite)) return false;
        sprite = (T?)tempSprite;
        return true;
    }
}