
using System.Numerics;

class Player
{
    public Rectangle Hitbox = new(360, 250, 80, 20);
    public int Level = 1;
    public int ExpMax = 100;
    public int Exp = 0;
    public int Hp = 200;
    public int HitPointMax = 200;
    public float Speed = 5;
    public int StaminaMax = 100;
    public int Hunger = 100;
    public int HungerMax = 100;
    public int Stamina = 100;
    public Vector2 movement = new Vector2(0.1f,0.1f);
    public void Update()
    {
        
        movement = Vector2.Zero;

        if (Raylib.IsKeyDown(KeyboardKey.D)){
            movement.X += 1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.A)){
            movement.X -= 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.W)){
            movement.Y -= 1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.S));
        {
            movement.Y += 1;
        }
        if (movement.Length() > 0){
            movement = Vector2.Normalize(movement) * Speed;
        }
        
        Hitbox.X += (int)movement.X;
        Hitbox.Y += (int)movement.Y;

        // if (Raylib.IsKeyDown(KeyboardKey.A)) Hitbox.X -= Speed;
        // if (Raylib.IsKeyDown(KeyboardKey.D)) Hitbox.X += Speed;
        // if (Raylib.IsKeyDown(KeyboardKey.W)) Hitbox.Y -= Speed;
        // if (Raylib.IsKeyDown(KeyboardKey.S)) Hitbox.Y += Speed;
    }

    public void StamRecharge()
    {
        for (int Stamina = 100; Stamina < StaminaMax;)
        {
            Stamina +=1;
            Console.WriteLine("Added 1 stamina stat");
        }
    }

    public void Actions()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            Stamina-=5;
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(Hitbox, Color.Black);

        Raylib.DrawText($"{Stamina}",200,100, 32, Color.Black);
    }
}



/* public method (stamina)
for each second stamina < staminaMax
stamina += 1
*/


/*public method (action):
for every action :
-5 stamina

*/

