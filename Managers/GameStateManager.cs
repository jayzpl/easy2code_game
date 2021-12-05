using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using easy2code_game.MainCore;
using easy2code_game.Modes;

namespace easy2code_game.Managers
{
    public class GameStateManager : Component
    {
        private MenuMode menuMode = new MenuMode();
        private GameMode gameMode = new GameMode();
        public override void LoadContent(ContentManager Content)
        {
            menuMode.LoadContent(Content);
            gameMode.LoadContent(Content);
        }
    
        public override void Update(GameTime gameTime)
        {
            switch (Data.CurrentState)
            {
                case Data.Modes.Menu:
                    menuMode.Update(gameTime);
                    break;
                case Data.Modes.Game:
                    gameMode.Update(gameTime);
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.Modes.Menu:
                    menuMode.Draw(spriteBatch);
                    break;
                case Data.Modes.Game:
                    gameMode.Draw(spriteBatch);
                    break;
            }
        }
    }
}