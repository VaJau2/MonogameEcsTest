using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;

namespace MonoEcsTest.Characters.Moving;

public class MovableAnimationSystem: EntityProcessingSystem
{
    private ComponentMapper<AnimatedSprite> spriteMapper;
    private ComponentMapper<Movable> movableMapper;
    
    public MovableAnimationSystem() : base(Aspect.All(typeof(AnimatedSprite), typeof(Movable)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        spriteMapper = mapperService.GetMapper<AnimatedSprite>();
        movableMapper = mapperService.GetMapper<Movable>();
    }

    public override void Process(GameTime gameTime, int entityId)
    {
        var sprite = spriteMapper.Get(entityId);
        var movable = movableMapper.Get(entityId);

        sprite.Play(GetAnimation(movable.velocity));
        
        var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        sprite.Update(deltaSeconds);
    }

    private static string GetAnimation(Vector2 velocity)
    {
        return velocity switch
        {
            { Y: > 0 } => "walkDown",
            { Y: < 0 } => "walkUp",
            { X: < 0 } => "walkLeft",
            { X: > 0 } => "walkRight",
            _ => "idle"
        };
    }
}
