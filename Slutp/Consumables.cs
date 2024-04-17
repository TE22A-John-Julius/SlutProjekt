class Consumables
{

    public static Rectangle Apple = new(16, 16, 80, 40);
    int AppleReplenish = 10;
    bool IsAppleEaten = false;

    
    List<Rectangle> Apples = new List<Rectangle>();

    public Consumables()
    {
        Apples.Add(Apple);
    }

    public void Update()
    {
        if (Raylib.CheckCollisionRecs(Player.Hitbox, Apple))
        {
            AppleReplenish += Player.Hunger;
            IsAppleEaten = true;
            Console.WriteLine("You have eaten the apple!");
            if (IsAppleEaten = true)
            {
                Apples.Remove(Apple);   
            }
        }
    }

    public void Draw()
    {
        foreach (Rectangle i in Apples)
        {
            Raylib.DrawRectangleRec(Apples[0], Color.Red);
        }

    }


}
