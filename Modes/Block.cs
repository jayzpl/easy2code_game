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
    public class Block
    {
        public Rectangle rect;
        public Texture2D texture;
        public Data.BlockType type;

        public bool isWorkingZone = false;

        public Block(Texture2D btexture, Data.BlockType btype)
        {
             this.texture = btexture;
             this.type = btype;
        }
        public void setRectangle(Rectangle brect)
        {
            this.rect = brect;
        }

        public void moveObject(MouseState ms_current, Rectangle ms_rect)
        {
            if(ms_current.LeftButton == ButtonState.Pressed && 
               this.rect.Contains(ms_rect) && 
               check_colision_left(this.rect, ms_rect) &&
               check_colision_right(this.rect, ms_rect) &&
               check_colision_up(this.rect, ms_rect) &&
               check_colision_down(this.rect, ms_rect))
            {

                this.rect.X = ms_current.X-(this.rect.Width/2);
                this.rect.Y = ms_current.Y-(this.rect.Height/2);
            }
        }
        public void checkIfBlockInWorkingZone(Rectangle working_zone)
        {
            if (working_zone.Contains(this.rect))
            {
                this.isWorkingZone = true;
            }
            else
            {
                this.isWorkingZone = false;
            }
        }
        private bool check_colision_left(Rectangle objectRect, Rectangle ms_rect)
        {
            if(ms_rect.X - (objectRect.Width/2) >= 5)
                return true;
            else return false;
        }
        private bool check_colision_right(Rectangle objectRect, Rectangle ms_rect)
        {
            if(ms_rect.X + (objectRect.Width/2) <= 1019)
                return true;
            else return false;
        }
        private bool check_colision_up(Rectangle objectRect, Rectangle ms_rect)
        {
            if(ms_rect.Y - (objectRect.Height/2) > 5)
                return true;
            else return false;
        }
        private bool check_colision_down(Rectangle objectRect, Rectangle ms_rect)
        {
            if(ms_rect.Y + (objectRect.Height/2) <= 600)
                return true;
            else return false;
        }
    }
}