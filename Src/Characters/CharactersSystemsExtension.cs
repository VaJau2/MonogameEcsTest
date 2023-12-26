using Microsoft.Xna.Framework.Content;
using MonoEcsTest.Characters.Destroying;
using MonoEcsTest.Characters.Moving;
using MonoEcsTest.Characters.Spawning;
using MonoGame.Extended.Entities;

namespace MonoEcsTest.Characters;

public static class CharactersSystemsExtension
{
    public static WorldBuilder AddCharacterSystems(this WorldBuilder world, ContentManager content)
    {
        return world.AddSystem(new SpawningCharactersSystem(content))
            .AddSystem(new MovingSystem())
            .AddSystem(new MovableAnimationSystem())
            .AddSystem(new BotsSystem())
            .AddSystem(new BotsTargetSystem())
            .AddSystem(new TargetsColoringSystem());
    }
}