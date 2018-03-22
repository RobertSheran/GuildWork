﻿using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Player
    {

        public string Name { get; set; }     
        public Board Board { get; set; }
        public bool IsTurn { get; set; }
        public Board PlayerBord { get; set; }


        public Player()
        {
            Name = UIInput.GetPlayerName();
            Board = UIInput.SetBoard();
        }
    }
}
