using System.Collections.Generic;
using System.Linq;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Entities;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities.Systems;

namespace MonoEcsTest.Rendering;

public class RenderSystem: EntityDrawSystem
{
    private readonly GraphicsDevice graphicsDevice;
    private readonly SpriteBatch spriteBatch;
    
    private ComponentMapper<Transform2> transformMapper;
    private ComponentMapper<Sprite> spriteMapper;
    
    public RenderSystem(GraphicsDevice graphicsDevice) 
        : base(Aspect.All(typeof(Sprite), typeof(Transform2)))
    {
        this.graphicsDevice = graphicsDevice;
        spriteBatch = new SpriteBatch(graphicsDevice);
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        transformMapper = mapperService.GetMapper<Transform2>();
        spriteMapper = mapperService.GetMapper<Sprite>();
    }

    public override void Draw(GameTime gameTime)
    {
        graphicsDevice.Clear(Color.CornflowerBlue);
        
        spriteBatch.Begin();

        foreach (var entity in YSortedEntities)
        {
            var transform = transformMapper.Get(entity);
            var sprite = spriteMapper.Get(entity);
            
            spriteBatch.Draw(sprite, transform);
        }

        spriteBatch.End();
    }

    private IEnumerable<int> YSortedEntities
    {
        get { return ActiveEntities.OrderBy(entityId => transformMapper.Get(entityId).Position.Y).ToArray(); }
    }
}