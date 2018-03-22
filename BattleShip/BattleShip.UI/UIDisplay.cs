using BattleShip.UI.UIEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;


namespace BattleShip.UI
{
    public class UIDisplay
    {
        public static void GeneralDisplay(DisplayEnum displayEnum)
        {

            switch (displayEnum)
            {
                case DisplayEnum.KeepPlaying:
                    Console.WriteLine("enter Q to quit, anything else will restart the game");
                    break;

                case DisplayEnum.PlaceDestroyer:
                    Console.WriteLine("Enter coordenate for destroyer. A-J followed by 1-10. Example: B7");
                    break;
                case DisplayEnum.ShipPlacementDirection:
                    Console.WriteLine("enter ship direction: up,down,left,right");
                    break;
                case DisplayEnum.PlaceCruiser:
                    Console.WriteLine("enter coordenate for Cruiser. A-J followed by 1-10. Example: B7");
                    break;

                case DisplayEnum.PlaceSubmarine:
                    Console.WriteLine("enter coordenate for Submarine. A-J followed by 1-10. Example: B7");
                    break;

                case DisplayEnum.SplashScreen:
                    
                    Console.WriteLine();
                       
                    Console.WriteLine("              ooooooooooo               ooooooooooo");
                    Console.WriteLine("          wwwwwwwwwww|||||          wwwwwwwwwww|||||");
                    Console.WriteLine("       wwwwwwwwwwww              wwwwwwwwwwww");
                    Console.WriteLine("    wwwwwwwwwwwwww            wwwwwwwwwwwwww");
                    Console.WriteLine("  wwwwwwwwwwwwwwwww        wwwwwwwwwwwwwwwww");
                    Console.WriteLine(" wwwwwwwwwwwwwwwwwww     wwwwwwwwwwwwwwwwwww");
                    Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwww wwwwwwwwwwwwwwwwwwwww                      Welcome to battle ship");
                    Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
                    for (int i = 1; i < 300; i++)
                    {
                        Console.Beep(i * 37, 2);
                    }
                    break;

                case DisplayEnum.ShipPlacementSuccess:
                    Console.WriteLine("ship placement successfull");
                    break;

                case DisplayEnum.GameOver:
                    Console.WriteLine("u win!");
                    break;

                case DisplayEnum.ShotHit:
                    Console.WriteLine("BIG HIT!");
                    break;


                case DisplayEnum.ShotMiss:
                    Console.WriteLine("you missed");
                    break;

                case DisplayEnum.PlaceCarrier:

                    Console.WriteLine("enter coordenate for Carrier. A-J followed by 1-10. Example: B7");
                    break;

                case DisplayEnum.PlaceBattleShip:
                    Console.WriteLine("enter coordenate for Battleship. A-J followed by 1-10. Example: B7");
                    break;

                case DisplayEnum.GetNames:
                    Console.WriteLine("Enter Name");
                    break;

                default:
                    Console.WriteLine("something went super wrong");
                    break;
            }
        }

        internal static void BoardSpacificDisplay(DisplayEnum drawBoard, Board board)
        {
            string pointIdentifier = "";

            Console.WriteLine("  1  2  3  4  5  6  7  8  9  10");
            for (int i = 1; i < 11; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.Write("A");
                        break;
                    case 2:
                        Console.Write("B");
                        break;
                    case 3:
                        Console.Write("C");
                        break;
                    case 4:
                        Console.Write("D");
                        break;
                    case 5:
                        Console.Write("E");
                        break;
                    case 6:
                        Console.Write("F");
                        break;
                    case 7:
                        Console.Write("G");
                        break;
                    case 8:
                        Console.Write("H");
                        break;
                    case 9:
                        Console.Write("I");
                        break;
                    case 10:
                        Console.Write("J");
                        break;

                }
                for (int n = 1; n < 11; n++)
                {
                    Coordinate coordinate = new Coordinate(i, n);
                    ShotHistory shotHistory = new ShotHistory();
                    shotHistory = board.CheckCoordinate(coordinate);

                    switch (shotHistory)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            pointIdentifier = "X";                           
                            break;

                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            pointIdentifier = "M";
                            break;
                        case ShotHistory.Unknown:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            pointIdentifier = "W";
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("error");
                            break;
                    }

                    Console.Write(" "+pointIdentifier+" ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
                Console.WriteLine();
            }


        }
        public static void NameSpecificDisplay(DisplayEnum displayEnum, string name)
        {
            if (displayEnum == DisplayEnum.Goesfirst)
            {
                Console.WriteLine(name + " you go first");
            }
            if (displayEnum == DisplayEnum.GetShot)
            {
                Console.WriteLine(name + " enter your shot. A-J followed by 1-10. Example: B7");
            }
        }

        public static void Error(DisplayEnum displayEnum)
        {

            switch (displayEnum)
            {
                case DisplayEnum.CoordinateFormatError:
                    Console.WriteLine("somehow your coordenate format was wrong, try again:");
                    Console.WriteLine("A - J followed by 1 - 10.Example: B7");
                    break;

                case DisplayEnum.ErrorDuplicate:             
                        Console.WriteLine("dupplicate shots arn't allowed. Try again:");
                        break;
                case DisplayEnum.ErrorDirection:
                    Console.WriteLine("somehow you entered an invalid direction, try again:");
                    Console.WriteLine("up,down,left, or right");
                    break;

                case DisplayEnum.ErrorOverlap:
                    Console.WriteLine("overlapping ships. Try again: ");
                    break;
                case DisplayEnum.NotENoughSpaceError:
                    Console.WriteLine("not enough space. Try again:");
                    break;
                default:
                    Console.WriteLine("Something went horrably wrong.");
                    break;


            }
        }

    }
}
