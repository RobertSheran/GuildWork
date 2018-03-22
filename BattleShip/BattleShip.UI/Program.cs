using BattleShip.UI.UIEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFlow gameFlow = new GameFlow();
            string keepPlaying="";
            do
            {
                gameFlow.Run();
                UIDisplay.GeneralDisplay(DisplayEnum.KeepPlaying);
                keepPlaying = Console.ReadLine().ToLower();
                Console.Clear();

            } while (keepPlaying != "q");
            
        }
    }
}
