global using Raylib_cs;

Raylib.InitWindow(1200, 1000, "Survival Game");
Raylib.SetTargetFPS(60);

Player player = new();
Consumables consumables = new();

while (!Raylib.WindowShouldClose())
{
    player.Update();
    player.Actions();
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.DarkBlue);
    player.Draw();
    consumables.Draw();
    consumables.Update();
    Raylib.EndDrawing();
}