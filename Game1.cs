using Microsoft.Xna.Framework;
using MonoEcsTest.Controls;
using MonoEcsTest.Entities;
using MonoEcsTest.Rendering;
using MonoGame.Extended.Entities;

namespace MonoEcsTest;

public class Game1 : Game
{
    private World _world;

    public Game1()
    {
        var deviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _world = new WorldBuilder()
            .AddSystem(new GameControlsSystem(this))
            .AddSystem(new RenderSystem(GraphicsDevice))
            .AddSystem(new CreateEntitiesSystem(Content))
            .Build();

        Components.Add(_world);
        base.Initialize();
    }
}
