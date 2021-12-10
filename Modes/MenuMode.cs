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
        private const int BUTTONS_NUMBER = 5;
        private Texture2D[] buttons = new Texture2D[BUTTONS_NUMBER];
        private Rectangle[] buttonsRect = new Rectangle[BUTTONS_NUMBER];
        
        private MouseState ms_current, ms_old;
        private Rectangle ms_rect;

        public override void LoadContent(ContentManager Content)
        {
            // game levels buttons
            const int INCREMENT_VALUE = 125;
            for (int i=0; i<buttons.Length; i++)
            {
                buttons[i] = Content.Load<Texture2D>($"rect3{i+1}");
                buttonsRect[i] = new Rectangle(700, 70 + (INCREMENT_VALUE*i), buttons[i].Width, buttons[i].Height);
            }
        }
    
        public override void Update(GameTime gameTime)
        {
            ms_old = ms_current;
            ms_current = Mouse.GetState();
            ms_rect = new Rectangle(ms_current.X, ms_current.Y, 1, 1);

            //selecting the lavel by clicking a button
            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[0])) //Level1
                Data.CurrentState = Data.Modes.Lvl1;

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[1])) //Level2
                Data.CurrentState = Data.Modes.Lvl2;

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[2])) //Level3
                Data.CurrentState = Data.Modes.Lvl3;

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[3])) //Level4
                Data.CurrentState = Data.Modes.Lvl4;

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[4])) //Level5
                Data.CurrentState = Data.Modes.Lvl5;
                
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
        }
    }
}