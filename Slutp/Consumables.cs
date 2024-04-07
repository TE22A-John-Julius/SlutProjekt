class Consumables{

    public Rectangle Apple = new(16, 16, 80, 40);
    int AppleReplenish = 10;


    public void Update(){
        if (Raylib.GetCollisionRec(Player.Hitbox, Apple)){

        }
    }




}
