using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;

namespace MonoEcsTest.Characters.Spawning;

public class SpawningCharactersSystem: EntityUpdateSystem
{
    private readonly Texture2D skeletonSprite;

    private ComponentMapper<Transform2> transformMapper;
    private ComponentMapper<Spawning> spawningMapper;
    
    public SpawningCharactersSystem(ContentManager content) : base(Aspect.All(typeof(Spawning)))
    {
        skeletonSprite = content.Load<Texture2D>("sprites/skeleton");
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        transformMapper = mapperService.GetMapper<Transform2>();
        spawningMapper = mapperService.GetMapper<Spawning>();
        
        InitSpawn();
    }

    private void InitSpawn()
    {
        CreateSkeleton(new Vector2(200, 200))
            .Attach(new Player());

        CreateSkeleton(new Vector2(300, 300), Color.Blue);
        CreateSkeleton(new Vector2(360, 300), Color.Red);
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var entityId in ActiveEntities)
        {
            var spawning = spawningMapper.Get(entityId);
            
            if (spawning.isSpawned)
            {
                if (spawning.cooldown > 0)
                {
                    spawning.cooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    GetEntity(entityId).Detach<Spawning>();
                }
                
                continue;
            }
            
            var transform = transformMapper.Get(entityId);
            CreateSkeleton(transform.Position, Color.Green);
            spawning.isSpawned = true;
            spawning.cooldown = Spawning.DEFAULT_COOLDOWN;
        }
    }

    private Entity CreateSkeleton(Vector2 pos, Color color = default)
    {
        var skeleton = CreateEntity();
        skeleton.Attach(new Transform2(pos));
        skeleton.Attach(new Movable());

        var sprite = new Sprite(skeletonSprite);
        if (color != default)
        {
            sprite.Color = color;
        }
        
        skeleton.Attach(sprite);
        return skeleton;
    }
}
