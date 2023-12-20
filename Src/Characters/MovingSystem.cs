using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace MonoEcsTest.Characters;

public class MovingSystem: EntityUpdateSystem
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

    public override void Update(GameTime gameTime)
    {
        foreach (var entityId in ActiveEntities)
        {
            var movable = movableMapper.Get(entityId);
            var transform = transformMapper.Get(entityId);

            if (movable.velocity.Length() > 0)
            {
                transform.Position += movable.velocity;
            }
        }
    }
}