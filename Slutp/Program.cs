global using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1200, 1000, "Survival Game");
Raylib.SetTargetFPS(60);

Player player = new();
string fireTexturePath = "Fire.png";
FireAnimation fireAnimation = new FireAnimation("Fire.png");

Consumables consumables = new();
while (!Raylib.WindowShouldClose())
{
    player.Update();
    player.Actions();
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.DarkBlue);

    consumables.Draw();
    consumables.Update();
    fireAnimation.Draw(new Vector2(600, 800), 0);
    fireAnimation.Update();
    player.Draw();
    Raylib.EndDrawing();
}