using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;

public class FireAnimation
{
    
    SpriteSheetInfo fireSpriteSheet;
    public FireAnimation(string texturePath)
    {
        Texture2D texture = Raylib.LoadTexture(texturePath);
        int frameWidth = texture.Width / 8;
        int frameHeight = texture.Height / 4;
        float frameTime = 0.1f;
        float frameCounter = 0.1f;
        fireSpriteSheet = new SpriteSheetInfo
        {
            texture = texture,
            frameWidth = frameWidth,
            frameHeight = frameHeight,
            numberOfFrames = 8,
            frameTime = frameTime,
            frameCounter = frameCounter
        };
    }

    public void Update()
    {
        fireSpriteSheet.frameCounter += Raylib.GetFrameTime();
        if (fireSpriteSheet.frameCounter >= fireSpriteSheet.frameTime)
        {
            fireSpriteSheet.frameCounter = 0;
            fireSpriteSheet.currentFrame++;
            if (fireSpriteSheet.currentFrame >= fireSpriteSheet.numberOfFrames)
            {
                fireSpriteSheet.currentFrame = 0;
            }
        }
    }

    public void Draw(Vector2 position, int row)
    {
        Rectangle sourceRect = new Rectangle(
            fireSpriteSheet.currentFrame * fireSpriteSheet.frameWidth,
            row * fireSpriteSheet.frameHeight,
            fireSpriteSheet.frameWidth,
            fireSpriteSheet.frameHeight
        );
        Raylib.DrawTextureRec(fireSpriteSheet.texture, sourceRect, position, Color.White);
    }
}


