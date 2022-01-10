using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using easy2code_game.MainCore;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace easy2code_game.Modes
{
    public class CheckResult
    {
        List<Block> blocks_in_working_zone = new List<Block>();
        List<Block> result = new List<Block>();
        string answer;
        public int points = 0;

        public CheckResult(string answer)
        {
            this.answer = answer;
        }

        public void checkOrderOfBlocks(Rectangle working_zone, List<Block> blocks)
        {
            foreach (Block block in blocks)
            {
                if (block.isWorkingZone){this.blocks_in_working_zone.Add(block);}
            }
            this.result = this.blocks_in_working_zone.OrderBy(x => x.rect.Y).ToList();  
        }

        public bool isAnswerGood()
        {
            string temp_answer = "";
            Data.BlockType previus_block;
            foreach (Block block in this.result)
            {
                previus_block = block.type;
                if (block.type == Data.BlockType.ZMIENNA)
                {
                    if (previus_block == Data.BlockType.PETLA)
                    {
                        temp_answer = temp_answer + ("111");
                    }
                    else
                    {
                        temp_answer = temp_answer + "1";
                    }
                }
            }
            if (temp_answer == this.answer) {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void countPoints()
        {
            if (this.result.Count < 3) {this.points = 10;}
            if (this.result.Count < 5) {this.points = 5;}
            if (this.result.Count < 10) {this.points = 2;}
        }
    }
}