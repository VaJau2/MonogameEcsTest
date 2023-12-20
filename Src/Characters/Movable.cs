using Microsoft.Xna.Framework;

namespace MonoEcsTest.Characters;

public class Movable
{
    private const int DEFAULT_SPEED = 3;
    
    public readonly int speed = DEFAULT_SPEED;
    public Vector2 velocity;
}
