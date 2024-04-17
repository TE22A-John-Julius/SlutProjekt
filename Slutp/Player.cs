
using System.Numerics;

class Player
{
    public static Rectangle Hitbox = new(360, 250, 80, 20);
    /*--------------------------------------//Level and EXP//--------------------------------------*/
    public int Level = 1;
    public int ExpMax = 100;
    public int Exp = 0;
    /*--------------------------------------//Hit Points//--------------------------------------*/
    public int Hp = 200;
    public int HitPointMax = 200;
    float HpSpeed = 0;
    /*--------------------------------------//HUNGER AND THIRST//--------------------------------------*/
    public static int Hunger = 80;
    public int HungerMax = 100;
    float HungerSpeed = 0;
    public int Thirst = 80;
    public int ThirstMax = 80;
    float ThirstSpeed = 0;
    public Rectangle Apple = new(16, 16, 80, 40);
    /*--------------------------------------//MOVEMENT AND STAM//--------------------------------------*/
    public int Stamina = 100;
    public Vector2 movement = new Vector2(0.1f, 0.1f);
    float StaminaSpeed = 0;
    public float Speed = 5;
    public int StaminaMax = 100;
    /*_____________________________________________________________________________________
    --------------------------------------//METHODS//--------------------------------------
    _______________________________________________________________________________________
    */
    public void Update()
    {
        /*--------------------------------------//STATS//--------------------------------------*/
        if (Stamina < StaminaMax)
        {

            StaminaSpeed += Raylib.GetFrameTime();

            if (StaminaSpeed > 1)
            {
                StaminaSpeed = 0;
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
            
            

        
        /*--------------------------------------//MOVEMENT//--------------------------------------*/
        movement = Vector2.Zero;

       if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            movement.Y = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            movement.Y = +1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            movement.X = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            movement.X = +1;
        }
        
        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * Speed;
        }
        Hitbox.X += (int)movement.X;
        Hitbox.Y += (int)movement.Y;
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
        Raylib.DrawRectangleRec(Hitbox, Color.Black);

        Raylib.DrawText($"Stamina: {Stamina}/100", 100, 100, 20, Color.Black);
        Raylib.DrawText($"Thirst: {Thirst}/80", 100, 200, 20, Color.Black);
        Raylib.DrawText($"Hunger: {Hunger}/80", 100, 300,20, Color.Black);
        Raylib.DrawText($"Health: {Hp}/200", 100, 400, 20, Color.Black);
    }






}


