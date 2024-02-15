class Player
{
    public Rectangle Hitbox = new(360, 550, 80, 20);
    public int Level = 1;
    public int Hp = 200;
    public int HitPointMax = 200;
    public int ExpMax = 100;
    public int Exp = 0;
    public float speed = 5;
    public int stamina = 50;   

    
    public void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.A)) Hitbox.X -= speed;
    }
}