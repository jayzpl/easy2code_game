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
    public class Level2 : AbstractGameDesign
    {
        private const int BUTTONS_NUMBER = 1;
        private Texture2D[] buttons = new Texture2D[BUTTONS_NUMBER];
        private Rectangle[] buttonsRect = new Rectangle[BUTTONS_NUMBER];
        
        private MouseState ms_current, ms_old;
        private Rectangle ms_rect;
        public override void LoadContent(ContentManager Content)
        {
            const int INCREMENT_VALUE = 125;
            buttons[0] = Content.Load<Texture2D>($"wstecz1");
            buttonsRect[0] = new Rectangle(10, 500 + (INCREMENT_VALUE*0), buttons[0].Width, buttons[0].Height);
        }
    
        public override void Update(GameTime gameTime)
        {
            ms_old = ms_current;
            ms_current = Mouse.GetState();
            ms_rect = new Rectangle(ms_current.X, ms_current.Y, 1, 1);

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[0])) //Menu
                Data.CurrentState = Data.Modes.Menu;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
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