global using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1200, 1000, "Survival Game");
Raylib.SetTargetFPS(60);

Player player = new();
string fireTexturePath = "Fire.png";
FireAnimation fireAnimation = new FireAnimation("Fire.png");
Consumables consumables = new();
TimeCycle timecycle = new();
/*--------------------------------------//DAY AND NIGHT//--------------------------------------*/
Texture2D dayTexture = Raylib.LoadTexture("jullegamebg.png");
Texture2D nightTexture = Raylib.LoadTexture("jullegamebg1.png");
Texture2D gamebg = dayTexture;
void Update()
{


    if (timecycle.isDay)
    {
        timecycle.dayTimer -= Raylib.GetFrameTime();

        if (timecycle.dayTimer <= 0)
        {
            timecycle.isDay = false;
            gamebg = nightTexture;
            timecycle.isNight = true;
        }
    }
    if (timecycle.isNight)
    {
        timecycle.nightTimer -= Raylib.GetFrameTime();

        if (timecycle.nightTimer <= 0)
        {
            timecycle.isNight = false;
            gamebg = dayTexture;
            timecycle.isDay = true;
        }
    }
}


while (!Raylib.WindowShouldClose())
{
    player.Update();
    player.Actions();
    Raylib.BeginDrawing();
    Update();
    Raylib.DrawTexture(gamebg, 0, 0, Color.White);
    consumables.Draw();
    consumables.Update();
    fireAnimation.Draw(new Vector2(600, 800), 0);
    fireAnimation.Update();
    player.Draw();
    Raylib.EndDrawing();
}