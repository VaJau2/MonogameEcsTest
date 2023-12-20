using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;

namespace MonoEcsTest.Entities;

public sealed class CreateEntitiesSystem: ISystem
{
    private readonly ContentManager content;
    
    public CreateEntitiesSystem(ContentManager content)
    {
        this.content = content;
    }
    
    public void Dispose() { }

    public void Initialize(World world)
    {
        var sprite = content.Load<Texture2D>("sprites/skeleton");  
        
        var skeleton = world.CreateEntity();
        skeleton.Attach(new Transform2(new Vector2(50, 50)));
        skeleton.Attach(new Sprite(sprite));
    }
}