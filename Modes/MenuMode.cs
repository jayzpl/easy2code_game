using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using easy2code_game.MainCore;
using Microsoft.Xna.Framework.Input;

namespace easy2code_game.Modes
{
    public class MenuMode : AbstractGameDesign
    {   
        private const int BUTTONS_NUMBER = 4;
        private Texture2D[] buttons = new Texture2D[BUTTONS_NUMBER];
        private Rectangle[] buttonsRect = new Rectangle[BUTTONS_NUMBER];
        
        private MouseState ms_current, ms_old;
        private Rectangle ms_rect;

        private Texture2D logo, help;
        private Rectangle logoRect, helpRect;

        public override void LoadContent(ContentManager Content)
        {
            // game levels buttons
            const int INCREMENT_VALUE = 125;
            for (int i=0; i<buttons.Length; i++)
            {
                buttons[i] = Content.Load<Texture2D>($"level{i+1}");
                buttonsRect[i] = new Rectangle(420, 200 + (INCREMENT_VALUE*i), buttons[i].Width, buttons[i].Height);
            }
            logo = Content.Load<Texture2D>("logo2");
            logoRect = new Rectangle(210,5,logo.Width, logo.Height);

            help = Content.Load<Texture2D>("info");
            helpRect = new Rectangle(455,680,help.Width, help.Height);

        }
    
        public override void Update(GameTime gameTime)
        {
            ms_old = ms_current;
            ms_current = Mouse.GetState();
            ms_rect = new Rectangle(ms_current.X, ms_current.Y, 1, 1);

            //selecting the lavel by clicking a button
            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[0]) && ms_old.LeftButton == ButtonState.Released) //Level1
                Data.CurrentState = Data.Modes.Lvl1;

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[1]) && ms_old.LeftButton == ButtonState.Released) //Level2
                Data.CurrentState = Data.Modes.Lvl2;

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[2]) && ms_old.LeftButton == ButtonState.Released) //Level3
                Data.CurrentState = Data.Modes.Lvl3;

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[3]) && ms_old.LeftButton == ButtonState.Released) //Level4
                Data.CurrentState = Data.Modes.Lvl4;

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(helpRect) && ms_old.LeftButton == ButtonState.Released) //Info
                Data.CurrentState = Data.Modes.Info;
                
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //drawing levels buttons
            for (int i=0; i<buttons.Length; i++)
            {
                spriteBatch.Draw(buttons[i], buttonsRect[i], Color.White);
                //hoverover the button
                if(ms_rect.Intersects(buttonsRect[i]))
                {
                    spriteBatch.Draw(buttons[i], buttonsRect[i], Color.Gray);
                }
            }
            spriteBatch.Draw(logo, logoRect, Color.White);
            spriteBatch.Draw(help, helpRect, Color.White);
            if(ms_rect.Intersects(helpRect))
            {
                spriteBatch.Draw(help, helpRect, Color.Gray);
            }
        }
    }
}