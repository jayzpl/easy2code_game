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
        private const int BUTTONS_NUMBER = 16;
        private const int BLOCKS_NUMBER = 16;
        private Texture2D[] buttons = new Texture2D[BUTTONS_NUMBER];
        private Texture2D[] blocks = new Texture2D[BLOCKS_NUMBER];
        private Rectangle[] buttonsRect = new Rectangle[BUTTONS_NUMBER];
        private Rectangle[] blocksRect = new Rectangle[BLOCKS_NUMBER];
        
        private MouseState ms_current, ms_old;
        private Rectangle ms_rect;

        private Texture2D answer, output, poczatek;
        private Rectangle answerRect, outputRect, poczatekRect;

        public override void LoadContent(ContentManager Content)
        {
            //exit button
            buttons[0] = Content.Load<Texture2D>("wstecz1");
            buttonsRect[0] = new Rectangle(5, 700, buttons[0].Width, buttons[0].Height);
            buttons[1] = Content.Load<Texture2D>("podpowiedz");
            buttonsRect[1] = new Rectangle(5, 630, buttons[1].Width, buttons[1].Height);
            buttons[2] = Content.Load<Texture2D>("start");
            buttonsRect[2] = new Rectangle(200, 700, buttons[2].Width, buttons[2].Height);

            //load blocks
            blocks[0] = Content.Load<Texture2D>($"zmienna2");
            blocksRect[0] = new Rectangle(3, 30, blocks[0].Width, blocks[0].Height);
            blocks[1] = Content.Load<Texture2D>($"zmienna2");
            blocksRect[1] = new Rectangle(3, 130, blocks[1].Width, blocks[1].Height);
            blocks[2] = Content.Load<Texture2D>($"zmienna2");
            blocksRect[2] = new Rectangle(3, 230, blocks[2].Width, blocks[2].Height);
            blocks[3] = Content.Load<Texture2D>($"petla2");
            blocksRect[3] = new Rectangle(3, 330, blocks[3].Width, blocks[3].Height);
            blocks[4] = Content.Load<Texture2D>($"warunek2");
            blocksRect[4] = new Rectangle(3, 430, blocks[4].Width-20, blocks[4].Height-10);

            //static blocks
            answer = Content.Load<Texture2D>("odpowiedz1");
            answerRect = new Rectangle(600, 700, answer.Width-100, answer.Height-10);
            output = Content.Load<Texture2D>("wynik");
            outputRect = new Rectangle(600, 640, output.Width, output.Height-10);
            poczatek = Content.Load<Texture2D>("poczatek");
            poczatekRect = new Rectangle(440, 5, poczatek.Width-30, poczatek.Height-30);
            
        }
    
        public override void Update(GameTime gameTime)
        {
            ms_old = ms_current;
            ms_current = Mouse.GetState();
            ms_rect = new Rectangle(ms_current.X, ms_current.Y, 1, 1);

            //switching exit button
            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[0]) && ms_old.LeftButton == ButtonState.Released)
                Data.CurrentState = Data.Modes.Menu;
            
            //switching podpowiedz button
            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(buttonsRect[1]) && ms_old.LeftButton == ButtonState.Released)
                Data.CurrentState = Data.Modes.Podpowiedz1;
            
            for (int i=0; i < blocks.Length; i++)
            {
                moveObject(i);
            }
            
            
        }

        public void moveObject(int i)
        {
            if(ms_current.LeftButton == ButtonState.Pressed && 
               blocksRect[i].Contains(ms_rect) && 
               check_colision_left(blocksRect[i]) &&
               check_colision_right(blocksRect[i]) &&
               check_colision_up(blocksRect[i]) &&
               check_colision_down(blocksRect[i]))
            {
                blocksRect[i].X = ms_current.X-(blocksRect[i].Width/2);
                blocksRect[i].Y = ms_current.Y-(blocksRect[i].Height/2);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            drawing_objects(spriteBatch, buttons, buttonsRect);
            drawing_objects(spriteBatch, blocks, blocksRect);
            spriteBatch.Draw(answer, answerRect, Color.White);
            spriteBatch.Draw(output, outputRect, Color.White);
            spriteBatch.Draw(poczatek, poczatekRect, Color.White);
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
            if(ms_rect.Y + (objectRect.Height/2) <= 600)
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