using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace MonoEcsTest.Characters.Moving;

public class MovingSystem: EntityProcessingSystem
{
    private ComponentMapper<Movable> movableMapper;
    private ComponentMapper<Transform2> transformMapper;
    
    public MovingSystem() : base(Aspect.All(typeof(Movable)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        movableMapper = mapperService.GetMapper<Movable>();
        transformMapper = mapperService.GetMapper<Transform2>();
    }

    public override void Process(GameTime gameTime, int entityId)
    {
        var movable = movableMapper.Get(entityId);
        var transform = transformMapper.Get(entityId);

        if (movable.velocity.Length() > 0)
        {
            transform.Position += movable.velocity;
        }
    }
}