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
    public class GameFlow
    {


        public Player[] Start()
        {
            Player[] players = new Player[2];
            UIDisplay.GeneralDisplay(DisplayEnum.SplashScreen);
            Console.Clear();

            Player xPlayer = new Player();
            Player yPlayer = new Player();

            Board xBoard = xPlayer.Board;
            Board yBoard = yPlayer.Board;

            if (UIInput.PlayerOneTurn())
            {
                UIDisplay.NameSpecificDisplay(DisplayEnum.Goesfirst, xPlayer.Name);

                xPlayer.IsTurn = true;
                yPlayer.IsTurn = false;
            }

            else
            {
                UIDisplay.NameSpecificDisplay(DisplayEnum.Goesfirst, yPlayer.Name);


                yPlayer.IsTurn = true;
                xPlayer.IsTurn = false;
            }

            players[0] = xPlayer;
            players[1] = yPlayer;
            return players;
        }
        



        public void Run()
        {
            Player[] players = Start();

            Player xPlayer = players[0];
            Player yPlayer = players[1];
            

            bool keepPlaying = true;


            while (keepPlaying)
            {
                if (yPlayer.IsTurn&&keepPlaying)
                {
                    UIDisplay.BoardSpacificDisplay(DisplayEnum.DrawBoard,xPlayer.Board);
                    UIDisplay.NameSpecificDisplay(DisplayEnum.GetShot, yPlayer.Name);
                    Coordinate shotCoordenate= UIInput.GetCoordenateFromUser();
                    FireShotResponse fireShot = new FireShotResponse();
                    fireShot = xPlayer.Board.FireShot(shotCoordenate);
                    
                    while (fireShot.ShotStatus == ShotStatus.Duplicate)
                    {
                        UIDisplay.Error(DisplayEnum.ErrorDuplicate);
                        shotCoordenate = UIInput.GetCoordenateFromUser();
                        fireShot = xPlayer.Board.FireShot(shotCoordenate);
                    }
                    
                    switch (fireShot.ShotStatus)
                    {
                        case ShotStatus.Victory:
                            UIDisplay.GeneralDisplay(DisplayEnum.GameOver);
                            keepPlaying = false;
                            break;

                        case ShotStatus.HitAndSunk:
                            Console.WriteLine(fireShot.ShipImpacted + " hit and sunk");
                            break;

                        case ShotStatus.Miss:
                            UIDisplay.GeneralDisplay(DisplayEnum.ShotMiss);
                            break;

                        case ShotStatus.Hit:
                            UIDisplay.GeneralDisplay(DisplayEnum.ShotHit);
                            break;

                        default:
                            Console.WriteLine("Something went very wrong");
                            break;
                    }


                    Console.ReadLine();
                    Console.Clear();
                    yPlayer.IsTurn = false;
                    xPlayer.IsTurn = true;
                }

                if(xPlayer.IsTurn&&keepPlaying)
                {
                    UIDisplay.BoardSpacificDisplay(DisplayEnum.DrawBoard, yPlayer.Board);
                    UIDisplay.NameSpecificDisplay(DisplayEnum.GetShot, xPlayer.Name);
                    Coordinate shotCoordenate = UIInput.GetCoordenateFromUser();
                    FireShotResponse fireShot = new FireShotResponse();
                    fireShot = yPlayer.Board.FireShot(shotCoordenate);
                    while (fireShot.ShotStatus == ShotStatus.Duplicate)
                    {
                        UIDisplay.Error(DisplayEnum.ErrorDuplicate);
                        shotCoordenate = UIInput.GetCoordenateFromUser();
                        fireShot = yPlayer.Board.FireShot(shotCoordenate);
                    }

                    switch (fireShot.ShotStatus)
                    {
                        case ShotStatus.Victory:
                            UIDisplay.GeneralDisplay(DisplayEnum.GameOver);
                            keepPlaying = false;
                            break;

                        case ShotStatus.HitAndSunk:
                            Console.WriteLine(fireShot.ShipImpacted + " hit and sunk");
                            break;

                        case ShotStatus.Miss:
                            UIDisplay.GeneralDisplay(DisplayEnum.ShotMiss);
                            break;

                        case ShotStatus.Hit:
                            UIDisplay.GeneralDisplay(DisplayEnum.ShotHit);
                            break;
                        default:
                            Console.WriteLine("Something went very wrong");
                            break;

                    }
                    Console.ReadLine();
                    Console.Clear();
                    xPlayer.IsTurn = false;
                    yPlayer.IsTurn = true;

                }
            }
        }
    }
}
