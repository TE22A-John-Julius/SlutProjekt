
using System.Numerics;


public class SpriteSheetInfo
{
    public Texture2D texture;
    public int frameWidth;
    public int frameHeight;
    public int numberOfFrames;
    public float frameTime;
    public float frameCounter;
    public int currentFrame;
}
class Player
{
    public static Rectangle Hitbox = new(360, 250, 80, 20);
    public static Rectangle warmArea = new(580, 840, 100, 100);
    /*--------------------------------------//Level and EXP//--------------------------------------*/

    public int Level = 1;
    public int ExpMax = 100;
    public int Exp = 0;
    /*--------------------------------------//Hit Points//--------------------------------------*/

    public int Hp = 200;
    public int HitPointMax = 200;
    float HpSpeed = 0;
    public static bool Cold = true;
    float ColdDmg = 0;
    /*--------------------------------------//HUNGER AND THIRST//--------------------------------------*/

    public static int Hunger = 80;
    public int HungerMax = 100;
    float HungerSpeed = 0;
    public int Thirst = 80;
    public int ThirstMax = 80;
    float ThirstSpeed = 0;
    /*--------------------------------------//MOVEMENT AND STAM//--------------------------------------*/

    public int Stamina = 100;
    public Vector2 movement = new Vector2(0.1f, 0.1f);
    float staminaSpeed = 0;
    public float Speed = 5;
    public int StaminaMax = 100;

    /*--------------------------------------//SpriteSheet & Animation//--------------------------------------*/

    // /*Left*/
    // static Texture2D spriteSheetA = Raylib.LoadTexture("homelessman_a.png"); 
    // int frameWidthA = spriteSheetA.Width / 4;
    // int frameHeightA = spriteSheetA.Height;

    // /*Right*/
    // static Texture2D spriteSheetD = Raylib.LoadTexture("homelessman_d.png");
    // int frameWidthD = spriteSheetD.Width / 4;
    // int frameHeightD = spriteSheetD.Height;

    //  /*Right*/
    // static Texture2D spriteSheetW = Raylib.LoadTexture("homelessman_w.png");
    // int frameWidthW = spriteSheetW.Width / 4;
    // int frameHeightW = spriteSheetW.Height;

    public List<SpriteSheetInfo> spriteSheets = new List<SpriteSheetInfo>();
    public Player()
    {
        spriteSheets.Add(CreateSpriteSheetInfo("homelessman_a.png"));
        spriteSheets.Add(CreateSpriteSheetInfo("homelessman_d.png"));
        spriteSheets.Add(CreateSpriteSheetInfo("homelessman_w.png"));
        spriteSheets.Add(CreateSpriteSheetInfo("homelessman_s.png"));
    }
    SpriteSheetInfo CreateSpriteSheetInfo(string filename)
    {
        Texture2D texture = Raylib.LoadTexture(filename);
        int frameWidth = texture.Width / 4;
        int frameHeight = texture.Height;
        int numberOfFrames = 4;
        float frameTime = 0.1f;
        float frameCounter = 0.1f;

        return new SpriteSheetInfo
        {
            texture = texture,
            frameWidth = frameWidth,
            frameHeight = frameHeight,
            numberOfFrames = numberOfFrames,
            frameTime = frameTime,
            frameCounter = frameCounter
        };
    }
    // int currentFrame = 0;
    // int numberOfFrames = 4;
    // float frameTime = 0.1f;
    // float frameCounter = 0.1f;


    /*_____________________________________________________________________________________
    --------------------------------------//METHODS//--------------------------------------
    _______________________________________________________________________________________
    */
    public void Update()
    {
        /*--------------------------------------//STATS//--------------------------------------*/
        if (Stamina < StaminaMax)
        {

            staminaSpeed += Raylib.GetFrameTime();

            if (staminaSpeed > 1)
            {
                staminaSpeed = 0;
                Stamina += 3;

            }
        }
        if (Thirst <= ThirstMax)
        {

            ThirstSpeed += Raylib.GetFrameTime();

            if (ThirstSpeed > 5)
            {
                ThirstSpeed = 0;
                Thirst -= 1;

            }
        }
        if (Hunger <= HungerMax)
        {

            HungerSpeed += Raylib.GetFrameTime();

            if (HungerSpeed > 10)
            {
                HungerSpeed = 0;
                Hunger -= 1;

            }
        }
        if (Hunger == 0 || Thirst == 0)
        {
            HpSpeed += Raylib.GetFrameTime();

            if (HpSpeed > 1)
            {
                HpSpeed = 0;
                Hp -= 10;
            }
        }

        foreach (var spriteSheet in spriteSheets)
        {
            spriteSheet.frameCounter += Raylib.GetFrameTime();
            if (spriteSheet.frameCounter >= spriteSheet.frameTime)
            {
                spriteSheet.frameCounter = 0;
                spriteSheet.currentFrame++;
                if (spriteSheet.currentFrame >= spriteSheet.numberOfFrames)
                {
                    spriteSheet.currentFrame = 0;
                }
            }
        }

        /*--------------------------------------//MOVEMENT//--------------------------------------*/
        movement = Vector2.Zero;

        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            spriteSheets[2].frameTime = 0.1f;
            movement.Y = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            movement.Y = +1;
            spriteSheets[3].frameTime = 0.1f;
        }
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            spriteSheets[0].frameTime = 0.1f;
            movement.X = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            spriteSheets[1].frameTime = 0.1f;
            movement.X = +1;
        }

        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * Speed;
        }
        Hitbox.X += (int)movement.X;
        Hitbox.Y += (int)movement.Y;

        if (Raylib.CheckCollisionRecs(Hitbox, warmArea))
        {
            Cold = false;
        }
        if (Cold)
        {
            ColdDmg += Raylib.GetFrameTime();
            if (ColdDmg > 5)
            {
                ColdDmg = 0;
                Hp -= 10;
            }
        }
    }
    public void Actions()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            Stamina -= 5;
        }
    }
    /*_____________________________________________________________________________________
    --------------------------------------//Drawing//--------------------------------------
    _______________________________________________________________________________________
    */
    public void Draw()
    {
        Raylib.DrawRectangleRec(warmArea, Color.Blank);
        SpriteSheetInfo currentSpriteSheet = null;
        if (movement.X < 0)
            currentSpriteSheet = spriteSheets[0];
        else if (movement.X > 0)
            currentSpriteSheet = spriteSheets[1];
        else if (movement.Y < 0)
            currentSpriteSheet = spriteSheets[2];
        else if (movement.Y > 0)
            currentSpriteSheet = spriteSheets[3];

        if (currentSpriteSheet != null)
        {
            Rectangle sourceRect = new Rectangle(
                currentSpriteSheet.currentFrame * currentSpriteSheet.frameWidth,
                0,
                currentSpriteSheet.frameWidth,
                currentSpriteSheet.frameHeight
            );
            Raylib.DrawTextureRec(currentSpriteSheet.texture, sourceRect, new Vector2(Hitbox.X, Hitbox.Y), Color.White);
        }

        // Raylib.DrawText($"Stamina: {Stamina}/100", 100, 100, 20, Color.Black);
        // Raylib.DrawText($"Thirst: {Thirst}/80", 100, 200, 20, Color.Black);
        // Raylib.DrawText($"Hunger: {Hunger}/80", 100, 300, 20, Color.Black);
        // Raylib.DrawText($"Health: {Hp}/200", 100, 400, 20, Color.Black);

        Raylib.DrawRectangle(100, 100, 100, 15, Color.Gray);
        Raylib.DrawRectangle(100, 150, 80, 15, Color.Gray);
        Raylib.DrawRectangle(100, 200, 80, 15, Color.Gray);
        Raylib.DrawRectangle(100, 250, 200, 15, Color.Gray);
        Raylib.DrawRectangle(100, 100, Stamina, 15, Color.White);
        Raylib.DrawRectangle(100, 150, Thirst, 15, Color.White);
        Raylib.DrawRectangle(100, 200, Hunger, 15, Color.White);
        Raylib.DrawRectangle(100, 250, Hp, 15, Color.White);
    }






}


