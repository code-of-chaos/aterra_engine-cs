﻿
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Numerics;
using AterraEngine.Interfaces.Actors;
using AterraEngine.Types;
using Raylib_cs;

namespace AterraEngine.Actors;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Sprite : ISprite {
    public TextureId TextureId { get; set; } = null!;
    public Texture2D? Texture { get; set; } = null;
    public Rectangle SelectionBox { get; set; }
    
    public Color Tint { get; set; } = Color.White;

    public void Draw(Vector2 pos, float rot, Vector2 origin, Vector2 size, Vector2 worldToScreenSpace){
        var scaledOrigin = origin * worldToScreenSpace;
        var screenPos = pos * worldToScreenSpace;
        
        Console.WriteLine((
            Texture, SelectionBox, scaledOrigin
        ));
        
        Raylib.DrawTexturePro(
            (Texture2D)Texture!,
            SelectionBox,
            new Rectangle(screenPos.X, screenPos.Y, size.X * worldToScreenSpace.X, size.Y * worldToScreenSpace.Y),
            scaledOrigin, // we use the scaledOrigin here.
            rot,
            Tint
        );
    }
    
    public void DrawDebug(Vector2 pos, float rot, Vector2 origin, Vector2 size, Rectangle box, Vector2 worldToScreenSpace){
        // BOUNDING BOX
        var screenPosX = pos.X * worldToScreenSpace.X;
        var screenPosY = pos.Y * worldToScreenSpace.Y;
        var screenSizeX = size.X * worldToScreenSpace.X;
        var screenSizeY = size.Y * worldToScreenSpace.Y;

        // BOUNDING BOX
        var screenBox = new Rectangle(box.X * worldToScreenSpace.X, box.Y * worldToScreenSpace.Y, screenSizeX, screenSizeY);
        Raylib.DrawRectangleLines((int)screenBox.X, (int)screenBox.Y, (int)screenBox.Width, (int)screenBox.Height, Color.Red);

        // ROTATION
        const float length = 2000;
        Vector2 screenPos = new Vector2(screenPosX, screenPosY);
        Vector2 endPoint = screenPos + new Vector2((float)Math.Cos(Raylib.DEG2RAD * rot), (float)Math.Sin(Raylib.DEG2RAD * rot)) * length;
        Raylib.DrawLineV(screenPos, endPoint, Color.DarkGreen);
    }
}