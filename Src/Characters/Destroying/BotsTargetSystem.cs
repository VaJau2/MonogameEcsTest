using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace MonoEcsTest.Characters.Destroying;

public class BotsTargetSystem: EntityUpdateSystem
{
    private ComponentMapper<Bot> botMapper;
    private ComponentMapper<Target> targetMapper;
    private ComponentMapper<Transform2> transformMapper;
    
    public BotsTargetSystem() : base(
        Aspect.One(typeof(Bot), typeof(Target)).All(typeof(Transform2)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        botMapper = mapperService.GetMapper<Bot>();
        targetMapper = mapperService.GetMapper<Target>();
        transformMapper = mapperService.GetMapper<Transform2>();
    }

    public override void Update(GameTime gameTime)
    {
        var bots = ActiveEntities.Where(entityId => botMapper.Has(entityId));
        var targets = ActiveEntities.Where(entityId => targetMapper.Has(entityId)).ToArray();
        
        foreach (var botId in bots)
        {
            var bot = botMapper.Get(botId);
            bot.targetId = GetClosestTargetId(botId, targets);
        }
    }

    private int? GetClosestTargetId(int botId, IReadOnlyList<int> targets)
    {
        if (targets.Count <= 0) return null;
        
        var botPos = GetPos(botId);

        var closestTargetId = targets[0];
        var closestDistance = Vector2.Distance(botPos, GetPos(targets[0]));

        for (var i = 1; i < targets.Count; i++)
        {
            var tempDistance = Vector2.Distance(botPos, GetPos(targets[i]));
            if (!(tempDistance < closestDistance)) continue;
            
            closestDistance = tempDistance;
            closestTargetId = targets[i];
        }

        return closestTargetId;
    }

    private Vector2 GetPos(int entityId) => transformMapper.Get(entityId).Position;
}
