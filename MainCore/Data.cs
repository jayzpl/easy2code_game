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

        public enum Modes {Menu, Lvl1, Lvl2, Lvl3, Lvl4, Info, Podpowiedz1}
        public static Modes CurrentState {get; set;} = Modes.Menu;
        public static Modes OldState;

        public enum BlockType{ZMIENNA, PETLA, WARUNEK, BUTTON, ELEMENT}

        public static string displayText1 = " ";
        public static string displayText2 = " ";
        public static string infoText1 = "Easy2Code to gra \nktora za cel obiera nauczenie uzytkownika \npodstaw tworzenia algorymtow i programowania! \nUkladaj bloczki w odpowiedniej kolejnosci \nprzeciagajac je aby dostac wymagany wynik.";
        public static string infoText2 = "Uzywaj swojej wyobrazni i kreatywnego myslenia. \nW kazdym poziomie mozesz skorzystac z podpowiedzi. \nBaw sie dobrze i powodzenia !";
    
        public static string lvl2Text1 = "Lvl2: Petle to polecania ktore wykonuja jakies instrukcje okreslona\nilosc razy";
        public static string lvl2Text2 = "W tym zadaniu petla wykonuje to co pod nia\n dokladnie 3 razy";

        public static string lvl3Text1 = "Lvl3: Petle i zmienne mozna tak ustawiac aby odstac odpowiedni wynik";
        public static string lvl3Text2 = "Podpowiedz: \npetla wykonuje to co pod nia dokladnie 3 razy";

        public static string lvl4Text1 = "Lvl4: Za pomoca petl i zmiennych ustaw wlasny algorytm";
        public static string lvl4Text2 = "\nPodpowiedz: \npetla wykonuje to co pod nia dokladnie 3 razy";

        public static string lvl1Text1 = "Lvl1: Zmienne przechowuja dane np. liczby. \nUloz bloczki zmiennych tak aby powstal wynik 1,1,1. \nKazda zmienna w tym zadaniu ma wartosc '1'";
        public static string lvl1Text2 = "Mozesz tez sprobowac zrobic to inaczej. \nPodpowiedz: \npetla wykonuje to co pod nia dokladnie 3 razy";
    
    }
}