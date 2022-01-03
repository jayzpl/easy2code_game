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
    public class Level1 : AbstractGameDesign
    {
        private const int BUTTONS_NUMBER = 15;
        private const int BLOCKS_NUMBER = 1;
        private int generate_counter = 0;
        private Texture2D[] buttons = new Texture2D[BUTTONS_NUMBER];
        private Texture2D[] blocks = new Texture2D[BLOCKS_NUMBER];
        //TODO try create list of blocks and dynamic generate objects
        private Rectangle[] buttonsRect = new Rectangle[BUTTONS_NUMBER];
        private Rectangle[] blocksRect = new Rectangle[BLOCKS_NUMBER];
        
        private MouseState ms_current, ms_old;
        private Rectangle ms_rect;
        public override void LoadContent(ContentManager Content)
        {
            //exit button
            buttons[0] = Content.Load<Texture2D>("wstecz");
            buttonsRect[0] = new Rectangle(5, 670, buttons[0].Width, buttons[0].Height);

            //load buttons to generate blocks
            buttons[1] = Content.Load<Texture2D>($"target");
            buttonsRect[1] = new Rectangle(3, 30, buttons[1].Width, buttons[1].Height);
            buttons[2] = Content.Load<Texture2D>($"target");
            buttonsRect[2] = new Rectangle(3, 130, buttons[2].Width, buttons[2].Height);
            buttons[3] = Content.Load<Texture2D>($"target");
            buttonsRect[3] = new Rectangle(3, 230, buttons[3].Width, buttons[3].Height);     
        }
    
        public override void Update(GameTime gameTime)
        {
            ms_old = ms_current;
            ms_current = Mouse.GetState();
            ms_rect = new Rectangle(ms_current.X, ms_current.Y, 1, 1);

            //switching exit button
            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[0]))
                Data.CurrentState = Data.Modes.Menu;

            //generate object
            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[1]))
            {
                    generate_counter = generate_counter + 1;
            }
            
            /*
            if(ms_current.LeftButton == ButtonState.Pressed && 
               blocksRect[0].Contains(ms_rect) && 
               check_colision_left(blocksRect[0]) &&
               check_colision_right(blocksRect[0]) &&
               check_colision_up(blocksRect[0]) &&
               check_colision_down(blocksRect[0]))
            {
                blocksRect[0].X = ms_current.X-(blocksRect[0].Width/2);
                blocksRect[0].Y = ms_current.Y-(blocksRect[0].Height/2);
            }
            */
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            drawing_objects(spriteBatch, buttons, buttonsRect);
            drawing_objects(spriteBatch, blocks, blocksRect);

        }

        private bool check_colision_left(Rectangle objectRect)
        {
            if(ms_rect.X - (objectRect.Width/2) >= 10)
                return true;
            else return false;
        }
        private bool check_colision_right(Rectangle objectRect)
        {
            if(ms_rect.X + (objectRect.Width/2) <= 1019)
                return true;
            else return false;
        }
        private bool check_colision_up(Rectangle objectRect)
        {
            if(ms_rect.Y - (objectRect.Height/2) > 10)
                return true;
            else return false;
        }
        private bool check_colision_down(Rectangle objectRect)
        {
            if(ms_rect.Y + (objectRect.Height/2) <= 500)
                return true;
            else return false;
        }

        private void drawing_objects(SpriteBatch spriteBatch, Texture2D[] objects, Rectangle[] objectsRect)
        {
            for (int i=0; i<objects.Length; i++) //drawing objects like blocks or buttons
            {
                try
                {
                spriteBatch.Draw(objects[i], objectsRect[i], Color.White);
                //hoverover the object
                if(ms_rect.Intersects(objectsRect[i]))
                {
                    spriteBatch.Draw(objects[i], objectsRect[i], Color.Gray);
                }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}