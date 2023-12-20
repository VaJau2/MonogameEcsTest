using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoEcsTest.Characters;
using MonoEcsTest.Characters.Moving;
using MonoEcsTest.Characters.Spawning;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace MonoEcsTest.Controls;

public class PlayerInputSystem: EntityProcessingSystem
{
    private ComponentMapper<Movable> movableMapper;
    private ComponentMapper<Spawning> spawningMapper;
    
    public PlayerInputSystem() 
        : base(Aspect.All(typeof(Movable), typeof(Player)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        movableMapper = mapperService.GetMapper<Movable>();
        spawningMapper = mapperService.GetMapper<Spawning>();
    }

    public override void Process(GameTime gameTime, int entityId)
    {
        var movable = movableMapper.Get(entityId);
        movable.velocity = GetInput() * movable.speed;

        if (MaySpawn(entityId) && Keyboard.GetState().IsKeyDown(Keys.Space))
        {
            spawningMapper.Put(entityId, new Spawning());
        }
    }

    private bool MaySpawn(int entityId) => !spawningMapper.Has(entityId);

    private Vector2 GetInput()
    {
        var input = Vector2.Zero;
        
        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            input.Y -= 1;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
            input.X -= 1;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            input.Y += 1;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            input.X += 1;
        }

        return input;
    }
}
