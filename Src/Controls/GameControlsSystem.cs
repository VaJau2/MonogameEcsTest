using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities.Systems;

namespace MonoEcsTest.Controls;

public class GameControlsSystem: UpdateSystem
{
    private Game1 game;
    
    public GameControlsSystem(Game1 game)
    {
        this.game = game;
    }

    public override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            game.Exit();
        }
    }
}