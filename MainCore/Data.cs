using System;
using System.Collections.Generic;
using System.Text;

namespace easy2code_game.MainCore
{
    public static class Data
    {
        public static int ScreenWidth { get; set;} = 1024;
        public static int ScreenHeight { get; set;} = 768;

        public static bool Exit {get; set;} = false;

        public enum Modes {Menu, Game}
        public static Modes CurrentState {get; set;} = Modes.Menu;
    }
}