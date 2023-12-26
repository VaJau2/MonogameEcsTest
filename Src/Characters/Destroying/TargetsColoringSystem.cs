using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;

namespace MonoEcsTest.Characters.Destroying;

public class TargetsColoringSystem: EntityProcessingSystem
{
    private ComponentMapper<Target> targetMapper;
    private ComponentMapper<AnimatedSprite> spriteManager;
    
    public TargetsColoringSystem() : base(Aspect.All(typeof(Target), typeof(AnimatedSprite)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        targetMapper = mapperService.GetMapper<Target>();
        spriteManager = mapperService.GetMapper<AnimatedSprite>();
    }

    public override void Process(GameTime gameTime, int entityId)
    {
        var target = targetMapper.Get(entityId);
        target.livingTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

        var targetSprite = spriteManager.Get(entityId);
        targetSprite.Color = GetColor(target.livingTime);
    }

    private static Color GetColor(float livingTime)
    {
        var color = Target.LIVING_COLORS[0];
        
        foreach (var timeValue in Target.LIVING_COLORS.Keys)
        {
            if (livingTime > timeValue)
            {
                color = Target.LIVING_COLORS[timeValue];
            }

            if (livingTime < timeValue) break;
        }

        return color;
    }
}