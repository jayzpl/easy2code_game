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
    public class GameStateManager : AbstractGameDesign
    {
        private MenuMode menuMode = new MenuMode();
        private Level1 lvl1 = new Level1();
        private Level2 lvl2 = new Level2();
        private Level3 lvl3 = new Level3();
        private Level4 lvl4 = new Level4();
        private Info info = new Info();
        public override void LoadContent(ContentManager Content)
        {
            menuMode.LoadContent(Content);
            lvl1.LoadContent(Content);
            lvl2.LoadContent(Content);
            lvl3.LoadContent(Content);
            lvl4.LoadContent(Content);
            info.LoadContent(Content);
        }
    
        public override void Update(GameTime gameTime)
        {
            switch (Data.CurrentState)
            {
                case Data.Modes.Menu:
                    menuMode.Update(gameTime);
                    break;
                case Data.Modes.Lvl1:
                    lvl1.Update(gameTime);
                    break;
                case Data.Modes.Lvl2:
                    lvl2.Update(gameTime);
                    break;
                case Data.Modes.Lvl3:
                    lvl3.Update(gameTime);
                    break;
                case Data.Modes.Lvl4:
                    lvl4.Update(gameTime);
                    break;
                case Data.Modes.Info:
                    info.Update(gameTime);
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
                case Data.Modes.Lvl1:
                    lvl1.Draw(spriteBatch);
                    break;
                case Data.Modes.Lvl2:
                    lvl2.Draw(spriteBatch);
                    break;
                case Data.Modes.Lvl3:
                    lvl3.Draw(spriteBatch);
                    break;
                case Data.Modes.Lvl4:
                    lvl4.Draw(spriteBatch);
                    break;
                case Data.Modes.Info:
                    info.Draw(spriteBatch);
                    break;
            }
        }
    }
}