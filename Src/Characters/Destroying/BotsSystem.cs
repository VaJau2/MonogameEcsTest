using Microsoft.Xna.Framework;
using MonoEcsTest.Characters.Moving;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace MonoEcsTest.Characters.Destroying;

public class BotsSystem: EntityProcessingSystem
{
    private ComponentMapper<Movable> movableMapper;
    private ComponentMapper<Bot> botMapper;
    private ComponentMapper<Transform2> transformMapper;
    
    public BotsSystem() 
        : base(Aspect.All(typeof(Movable), typeof(Bot)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        movableMapper = mapperService.GetMapper<Movable>();
        botMapper = mapperService.GetMapper<Bot>();
        transformMapper = mapperService.GetMapper<Transform2>();
    }

    public override void Process(GameTime gameTime, int entityId)
    {
        var bot = botMapper.Get(entityId);

        if (bot.targetId is not { } targetId) return;
        if (!transformMapper.Has(targetId)) return;

        var movable = movableMapper.Get(entityId);
        var botPos = GetPos(entityId);
        var targetPos = GetPos(targetId);

        if (Vector2.Distance(botPos, targetPos) > Bot.DESTROY_DISTANCE)
        {
            movable.velocity = GetDir(botPos, targetPos) * movable.speed;
        }
        else
        {
            DestroyEntity(targetId);
            movable.velocity = Vector2.Zero;
            bot.targetId = null;
        }
    }
    
    private Vector2 GetPos(int entityId) => transformMapper.Get(entityId).Position;
    
    private static Vector2 GetDir(Vector2 botPos, Vector2 targetPos)
    {
        return Vector2.Normalize(targetPos - botPos);
    }
}