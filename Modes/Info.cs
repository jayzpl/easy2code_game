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
        private Texture2D back;
        private Rectangle ms_rect, backRect;

        private SpriteFont font;
        private Vector2 position1, position2, textMiddle1, textMiddle2;
        string text1 = Data.displayText1;
        string text2 = Data.displayText2;

        
        

        public override void LoadContent(ContentManager Content)
        {
            try
            {
            back = Content.Load<Texture2D>($"wstecz1");
            backRect = new Rectangle(5, 700, back.Width, back.Height);
            //textInfo = Content.Load<Texture2D>($"tekst_info1");
            //textInfoRect = new Rectangle(5, 5, 1000, 150);
            //textInfo2 = Content.Load<Texture2D>($"tekst_info2");
            //textInfoRect2 = new Rectangle(5, 250, 900, 110);
            font = Content.Load<SpriteFont>("arial");
            textMiddle1 = font.MeasureString(text1)/2;
            textMiddle2 = font.MeasureString(text2)/2;
            position1 = new Vector2(5, 5);
            position2 = new Vector2(5, 350); 
            }
            catch (Exception){}
        }
    
        public override void Update(GameTime gameTime)
        {
            ms_old = ms_current;
            ms_current = Mouse.GetState();
            ms_rect = new Rectangle(ms_current.X, ms_current.Y, 1, 1);

            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(backRect))
            {
                if (Data.OldState == Data.Modes.Menu){Data.CurrentState = Data.Modes.Menu;}
                if (Data.OldState == Data.Modes.Lvl1){Data.CurrentState = Data.Modes.Lvl1;}
                if (Data.OldState == Data.Modes.Lvl2){Data.CurrentState = Data.Modes.Lvl2;}
                if (Data.OldState == Data.Modes.Lvl3){Data.CurrentState = Data.Modes.Lvl3;}
                if (Data.OldState == Data.Modes.Lvl4){Data.CurrentState = Data.Modes.Lvl4;}
            }
                
        }

        public override void Draw(SpriteBatch spriteBatch)
        {   
            spriteBatch.Draw(back, backRect, Color.White);
            if(ms_rect.Intersects(backRect))
            {
                spriteBatch.Draw(back, backRect, Color.Gray);
            }
            spriteBatch.DrawString(font, text1, position1, Color.White);
            spriteBatch.DrawString(font, text2, position2, Color.White);
        }
    }
}