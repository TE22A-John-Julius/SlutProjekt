class Consumables
{

    /*PSEUDO
    for each apple in apples
    new vector2 = posx,posy
    posy = random
    posx = random

    list of apples

    for each apple in apples
    raylib draw rectangle with vector pos
    
    */

    public static Rectangle Apple = new(16, 16, 80, 40);
    int AppleReplenish = 10;
    bool IsAppleEaten = false;
    float AppleRespawnTimer = 0;
    Random Randomizer = new Random();
   
    
    List<Rectangle> Apples = new List<Rectangle>();

    public Consumables()
    {
        Apples.Add(Apple);
    }

    public void Update()
    {
        if (Raylib.CheckCollisionRecs(Player.Hitbox, Apple))
        {
            Player.Hunger += AppleReplenish;
            IsAppleEaten = true;
            Console.WriteLine("You have eaten the apple!");
            if (IsAppleEaten)
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

           /* AppleRespawnTimer += Raylib.GetFrameTime();
                if ( AppleRespawnTimer < 1)
                {
                   Apples.Add(Apple);

                } */
        }

    }


}
