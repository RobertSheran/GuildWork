using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI.UIEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class UIInput
    {
        public static string GetPlayerName()
        {
            string playerName;
            UIDisplay.GeneralDisplay(DisplayEnum.GetNames);
            playerName = Console.ReadLine();

            return playerName;
        }

        internal static Board SetBoard()
        {
            Board setBord = new Board();
            ShipType shipType = new ShipType();
            Coordinate shipCoordenate;
            ShipDirection shipDirection = new ShipDirection();


            for (ShipType i = ShipType.Destroyer; i <= ShipType.Carrier; i++)
            {

                switch (i)
                {
                    case ShipType.Destroyer:
                        UIDisplay.GeneralDisplay(DisplayEnum.PlaceDestroyer);
                        shipCoordenate = GetCoordenateFromUser();
                        shipType = ShipType.Destroyer;
                        break;
                    case ShipType.Submarine:
                        UIDisplay.GeneralDisplay(DisplayEnum.PlaceSubmarine);
                        shipCoordenate = GetCoordenateFromUser();
                        shipType = ShipType.Submarine;
                        break;
                    case ShipType.Carrier:
                        UIDisplay.GeneralDisplay(DisplayEnum.PlaceCarrier);
                        shipCoordenate = GetCoordenateFromUser();
                        shipType = ShipType.Carrier;
                        break;
                    case ShipType.Battleship:
                        UIDisplay.GeneralDisplay(DisplayEnum.PlaceBattleShip);
                        shipCoordenate = GetCoordenateFromUser();
                        shipType = ShipType.Battleship;
                        break;
                    default:
                        UIDisplay.GeneralDisplay(DisplayEnum.PlaceCruiser);
                        shipCoordenate = GetCoordenateFromUser();
                        shipType = ShipType.Cruiser;
                        break;
                }


                switch (GetDirection().ToLower())
                {
                    case "up":
                        shipDirection = ShipDirection.Up;
                        break;
                    case "down":
                        shipDirection = ShipDirection.Down;
                        break;
                    case "left":
                        shipDirection = ShipDirection.Left;
                        break;
                    default:
                        shipDirection = ShipDirection.Right;
                        break;
                }

                PlaceShipRequest placeShipRequest = new PlaceShipRequest
                {
                    Coordinate = shipCoordenate,
                    Direction = shipDirection,
                    ShipType = shipType
                };

                ShipPlacement shipPlacement = new ShipPlacement();
                shipPlacement = setBord.PlaceShip(placeShipRequest);


                if (shipPlacement == ShipPlacement.NotEnoughSpace)
                {
                    UIDisplay.Error(DisplayEnum.NotENoughSpaceError);
                    i--;
                }


                if (shipPlacement == ShipPlacement.Overlap)
                {
                    UIDisplay.Error(DisplayEnum.ErrorOverlap);
                    i--;
                }
            }

            Console.Clear();
            return setBord;
        }

        public static bool PlayerOneTurn()
        {
            Random random = new Random();
            return (random.Next(1, 3) % 2 == 0);
        }


        public static bool CheckFormatOfCoordinate(string coordinateString)
        {
            bool isValidCoordinate = false;

            if (coordinateString.Length >= 2 && coordinateString.Length <= 3)
            {
                if (char.IsLetter(coordinateString, 0))
                {
                    char firstPart = char.Parse(coordinateString.Substring(0, 1).ToLower());
                    switch (firstPart)
                    {
                        case 'a':
                            isValidCoordinate = true;
                            break;
                        case 'b':
                            isValidCoordinate = true;
                            break;
                        case 'c':
                            isValidCoordinate = true;
                            break;
                        case 'd':
                            isValidCoordinate = true;
                            break;
                        case 'e':
                            isValidCoordinate = true;
                            break;
                        case 'f':
                            isValidCoordinate = true;
                            break;
                        case 'g':
                            isValidCoordinate = true;
                            break;
                        case 'h':
                            isValidCoordinate = true;
                            break;
                        case 'i':
                            isValidCoordinate = true;
                            break;
                        case 'j':
                            isValidCoordinate = true;
                            break;
                        default:
                            isValidCoordinate = false;
                            break;
                    }
                    if (!int.TryParse(coordinateString.Substring(1), out int z))
                    {
                        isValidCoordinate = false;
                    }
                    if (z > 10 || z < 0)
                    {
                        isValidCoordinate = false;
                    }
                }

            }

            return isValidCoordinate;

        }

        public static Coordinate ConvertCoordinate(string str)
        {

            int xCoordinate = 0;
            int yCoordinate = 0;
            char firstPart = char.Parse(str.Substring(0, 1));
            switch (firstPart)
            {
                case 'a':
                    xCoordinate = 1;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
                case 'b':
                    xCoordinate = 2;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
                case 'c':
                    xCoordinate = 3;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
                case 'd':
                    xCoordinate = 4;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
                case 'e':
                    xCoordinate = 5;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
                case 'f':
                    xCoordinate = 6;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
                case 'g':
                    xCoordinate = 7;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
                case 'h':
                    xCoordinate = 8;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
                case 'i':
                    xCoordinate = 9;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
                default:
                    xCoordinate = 10;
                    yCoordinate = Convert.ToInt32(str.Substring(1));
                    break;
            }

            Coordinate coordinate = new Coordinate(xCoordinate, yCoordinate);
            return coordinate;
        }

        public static Coordinate GetCoordenateFromUser()
        {

            string userInput = Console.ReadLine();

            while (CheckFormatOfCoordinate(userInput) == false)
            {
                UIDisplay.Error(DisplayEnum.CoordinateFormatError);
                userInput = Console.ReadLine();
            }
            Coordinate coordinate = ConvertCoordinate(userInput);

            return coordinate;
        }
        public static bool TestDirection(string str)
        {
            bool testDirection = false;
            switch (str.ToLower())
            {
                case "up":
                    testDirection = true;
                    break;
                case "down":
                    testDirection = true;
                    break;
                case "left":
                    testDirection = true;
                    break;
                case "right":
                    testDirection = true;
                    break;
            }
            return testDirection;

        }

        public static string GetDirection()
        {
            string getDirection = "";

            UIDisplay.GeneralDisplay(DisplayEnum.ShipPlacementDirection);

            getDirection = Console.ReadLine();
            while (!TestDirection(getDirection))
            {
                UIDisplay.Error(DisplayEnum.ErrorDirection);
                getDirection = Console.ReadLine();
            }



            return getDirection;
        }
    }
}

