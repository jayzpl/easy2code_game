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
    public class Info : AbstractGameDesign
    {
        
        private MouseState ms_current, ms_old;
        private Rectangle ms_rect;
        private Texture2D back, textInfo, textInfo2;
        private Rectangle backRect, textInfoRect, textInfoRect2;

        private SpriteFont font;
        private Vector2 textMiddle;
        private Vector2 position;
        string text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";

        
        

        public override void LoadContent(ContentManager Content)
        {
            try
            {
            back = Content.Load<Texture2D>($"wstecz1");
            backRect = new Rectangle(5, 700, back.Width, back.Height);
            textInfo = Content.Load<Texture2D>($"tekst_info1");
            textInfoRect = new Rectangle(5, 5, 1000, 150);
            textInfo2 = Content.Load<Texture2D>($"tekst_info2");
            textInfoRect2 = new Rectangle(5, 250, 900, 110);

            font = Content.Load<SpriteFont>("arial");
            textMiddle = font.MeasureString(text)/2;
            position = new Vector2(100, 600);
            
            }
            catch (Exception){}
        }
    
        public override void Update(GameTime gameTime)
        {
            ms_old = ms_current;
            ms_current = Mouse.GetState();
            ms_rect = new Rectangle(ms_current.X, ms_current.Y, 1, 1);

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(backRect)) //Menu
                Data.CurrentState = Data.Modes.Menu;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            /*
            for (int i=0; i<buttons.Length; i++)
            {
                spriteBatch.Draw(buttons[i], buttonsRect[i], Color.White);

                //hoverover the button
                if(ms_rect.Intersects(buttonsRect[i]))
                {
                    spriteBatch.Draw(buttons[i], buttonsRect[i], Color.Gray);
                }
            }
            */
            
            spriteBatch.Draw(back, backRect, Color.White);
            spriteBatch.Draw(textInfo, textInfoRect, Color.White);
            spriteBatch.Draw(textInfo2, textInfoRect2, Color.White);
            if(ms_rect.Intersects(backRect))
            {
                    spriteBatch.Draw(back, backRect, Color.Gray);
            }

            //spriteBatch.DrawString(font, "AAAAAAAAAAAAAAAAAAAAAAAAAAAAA", position, Color.White, 0, textMiddle, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}