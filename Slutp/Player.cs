class Player
{
    public Rectangle Hitbox = new(360, 550, 80, 20);
    public int Level = 1;
      public int ExpMax = 100;
    public int Exp = 0;
    public int Hp = 200;
    public int HitPointMax = 200;
    public float Speed = 5;
    public int Stamina = 100;
    public int StaminaMax = 100;   
    public int Hunger = 100;
    public int HungerMax = 100;
    
    public void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.A)) Hitbox.X -= Speed;
    }

    public void Action()
    {
        for (int Stamina = 0; Stamina < StaminaMax; Stamina++)
        {
            
        }
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

