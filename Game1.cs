using Microsoft.Xna.Framework;
using MonoEcsTest.Characters;
using MonoEcsTest.Controls;
using MonoEcsTest.Rendering;
using MonoGame.Extended.Entities;

namespace MonoEcsTest;

public class Game1 : Game
{
    private World world;

    public Game1()
    {
        var deviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        world = new WorldBuilder()
            .AddSystem(new GameControlsSystem(this))
            .AddSystem(new RenderSystem(GraphicsDevice))
            .AddSystem(new PlayerInputSystem())
            .AddCharacterSystems(Content)
            .Build();

        Components.Add(world);
        base.Initialize();
    }
}
