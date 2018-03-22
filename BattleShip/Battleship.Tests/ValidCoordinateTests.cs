using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleShip.UI;

namespace Battleship.Tests
{
    [TestFixture]
    class ValidCoordinateTests
    {
        [Test]
        public void CoordinateTests()
        {
            bool actual = UIInput.CheckFormatOfCoordinate("aa");
            Assert.AreEqual(false, actual);
        }
    }
}
