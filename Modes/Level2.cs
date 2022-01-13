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
        private List<Block> blocks = new List<Block>();
        private List<Block> buttons = new List<Block>();
        private List<Block> elements = new List<Block>();

        private Block exit_button, hint_button, start_button, static_element, var_block1, var_block2, loop_block, loop_block2;
        
        private MouseState ms_current, ms_old;
        private Rectangle ms_rect, working_zone;

        private SpriteFont font;
        private string answer = ""; //this should allways be empty
        private string points = ""; //this should allways be empty
        private string task = "111111"; //here is the task result of this level 
        Vector2 position_answer, position_task, middle_answer, middle_task, position_points, middle_points; 

        public override void LoadContent(ContentManager Content)
        {
            Data.OldState = Data.Modes.Lvl1;
            Data.displayText1 = Data.lvl1Text1;
            Data.displayText2 = Data.lvl1Text2;

            //loading buttons
            hint_button = new Block(Content.Load<Texture2D>($"podpowiedz"), Data.BlockType.BUTTON);
            hint_button.setRectangle(new Rectangle(5, 630, hint_button.texture.Width, hint_button.texture.Height));
            exit_button = new Block(Content.Load<Texture2D>($"wstecz1"), Data.BlockType.BUTTON);
            exit_button.setRectangle(new Rectangle(5, 700, exit_button.texture.Width, exit_button.texture.Height));
            start_button = new Block(Content.Load<Texture2D>($"start"), Data.BlockType.BUTTON);
            start_button.setRectangle(new Rectangle(200, 700, start_button.texture.Width, start_button.texture.Height));
            
            buttons.Add(exit_button);
            buttons.Add(start_button);
            buttons.Add(hint_button);

            //loading static elements
            static_element = new Block(Content.Load<Texture2D>("zadany_wynik"), Data.BlockType.ELEMENT);
            static_element.setRectangle(new Rectangle(600, 700, static_element.texture.Width-25, static_element.texture.Height-3));
            elements.Add(static_element);
            static_element = new Block(Content.Load<Texture2D>("wynik"), Data.BlockType.ELEMENT);
            static_element.setRectangle(new Rectangle(590, 640, static_element.texture.Width, static_element.texture.Height-10));
            elements.Add(static_element);
            static_element = new Block(Content.Load<Texture2D>("poczatek"), Data.BlockType.ELEMENT);
            static_element.setRectangle(new Rectangle(440, 5, static_element.texture.Width-30, static_element.texture.Height-30));
            elements.Add(static_element);
            static_element = new Block(Content.Load<Texture2D>("upwall1"), Data.BlockType.ELEMENT);
            static_element.setRectangle(new Rectangle(10, 600, static_element.texture.Width-920, static_element.texture.Height-5));
            elements.Add(static_element);
            static_element = new Block(Content.Load<Texture2D>("verticalwall"), Data.BlockType.ELEMENT);
            static_element.setRectangle(new Rectangle(160, 5, static_element.texture.Width, static_element.texture.Height+470));
            elements.Add(static_element);

            //loading dynamic text fields
            font = Content.Load<SpriteFont>("arial");
            middle_answer = font.MeasureString(this.answer)/2;
            middle_task = font.MeasureString(this.task)/2;
            middle_points = font.MeasureString(this.points)/2;
            position_answer = new Vector2(770, 647);
            position_points = new Vector2(430, 690);
            position_task = new Vector2(905, 701);
            

            //loading blocks
            var_block1 = new Block(Content.Load<Texture2D>($"zmienna2"), Data.BlockType.ZMIENNA);
            var_block1.setRectangle(new Rectangle(3, 30, var_block1.texture.Width, var_block1.texture.Height));
            var_block2 = new Block(Content.Load<Texture2D>($"zmienna2"), Data.BlockType.ZMIENNA);
            var_block2.setRectangle(new Rectangle(3, 130, var_block2.texture.Width, var_block2.texture.Height));
            loop_block = new Block(Content.Load<Texture2D>($"petla2"), Data.BlockType.PETLA);
            loop_block.setRectangle(new Rectangle(3, 330, loop_block.texture.Width, loop_block.texture.Height));
            loop_block2 = new Block(Content.Load<Texture2D>($"petla2"), Data.BlockType.PETLA);
            loop_block2.setRectangle(new Rectangle(3, 430, loop_block.texture.Width, loop_block.texture.Height));

            blocks.Add(var_block1);
            blocks.Add(var_block2);
            blocks.Add(loop_block);
            blocks.Add(loop_block2);

            //loading zone for seting blocks
            working_zone = new Rectangle(160, 5, 1019, 600);
        }
    
        public override void Update(GameTime gameTime)
        {
            ms_old = ms_current;
            ms_current = Mouse.GetState();
            ms_rect = new Rectangle(ms_current.X, ms_current.Y, 1, 1);

            //checking if exit button has been clicked
            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(exit_button.rect) && ms_old.LeftButton == ButtonState.Released) //Menu
                Data.CurrentState = Data.Modes.Menu;
            
            //checking if hint button has been clicked
            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(hint_button.rect) && ms_old.LeftButton == ButtonState.Released){ //Hint
                Data.displayText1 = Data.lvl2Text1;
                Data.displayText2 = Data.lvl2Text2;
                Data.CurrentState = Data.Modes.Info;
            }

            //compile algorithm
            if(ms_current.LeftButton == ButtonState.Pressed && ms_rect.Intersects(start_button.rect) && ms_old.LeftButton == ButtonState.Released){
                CheckResult result = new CheckResult(this.task);
                result.checkOrderOfBlocks(working_zone, blocks);
                if (result.isAnswerGood())
                {
                    result.countPoints();
                    this.points = $"{result.points} pkt.";
                    this.answer = result.temp_answer;
                }
                else
                {
                    this.points = $"{result.points} pkt.";
                    this.answer = result.temp_answer;
                }

            
            }

            //moving blocks mechanic
            checkMovingBlocks(blocks);
            
        }

        private void checkMovingBlocks(List<Block> list)
        {
            foreach (Block block in list)
            {
                if (block.type != Data.BlockType.BUTTON && block.type != Data.BlockType.ELEMENT)
                {
                    block.moveObject(ms_current, ms_rect);
                    block.checkIfBlockInWorkingZone(working_zone);
                }
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                drawObjFromList(buttons, spriteBatch);
                drawObjFromList(elements, spriteBatch);
                drawObjFromList(blocks, spriteBatch);
                spriteBatch.DrawString(font, this.answer, position_answer, Color.White);
                spriteBatch.DrawString(font, this.points, position_points, Color.White);
                spriteBatch.DrawString(font, this.task, position_task, Color.White);
            }
            catch (Exception)
            {

            }
        }

        public void drawObjFromList(List<Block> list, SpriteBatch spriteBatch)
        {
            foreach (Block obj in list)
            {
                spriteBatch.Draw(obj.texture, obj.rect, Color.White);
                //hoverover the object
                if(ms_rect.Intersects(obj.rect) && obj.type != Data.BlockType.ELEMENT)
                {
                    spriteBatch.Draw(obj.texture, obj.rect, Color.Gray);
                }
            }
        }
    }
}