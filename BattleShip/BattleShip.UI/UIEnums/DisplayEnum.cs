using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.UIEnums
{
    public enum DisplayEnum
    {
        SplashScreen,
        GetNames,
        PlaceSubmarine,
        PlaceCruiser,
        PlaceCarrier,
        PlaceBattleShip,
        PlaceDestroyer,
        ShipPlacementDirection,
        Goesfirst,   
        GetShot,
        ShotHit,
        ShotMiss,
        ShotSunk,
        GameOver,  

        DrawBoard,

               

        CoordinateFormatError,
        ErrorDirection,
        NotENoughSpaceError,
        ErrorOverlap,
        ShipPlacementSuccess,
        ErrorDuplicate,
        KeepPlaying
    }
}
