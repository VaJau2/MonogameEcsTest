using Microsoft.Xna.Framework;

namespace MonoEcsTest.Characters.Moving;

public class Movable
{
    private const int DEFAULT_SPEED = 3;
    
    public readonly int speed;
    public Vector2 velocity;
    
    public Movable()
    {
        speed = DEFAULT_SPEED;
    }
    
    public Movable(int speed)
    {
        this.speed = speed;
    }
}
