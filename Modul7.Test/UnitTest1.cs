using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Modul7.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGoUp()
        {
            var elevator = new Modul7.Elevator("Elevator 1", 10, -2, 30, 0);
            var currentFloor = elevator.CurrentFloor;
            elevator.GoUp();
            Assert.AreEqual(elevator.CurrentFloor, currentFloor + 1);
        }

        [TestMethod]
        public void TestGoDown()
        {
            var elevator = new Modul7.Elevator("Elevator 1", 10, -2, 30, 0);
            var currentFloor = elevator.CurrentFloor;
            elevator.GoDown();
            Assert.AreEqual(elevator.CurrentFloor, currentFloor - 1);
        }

        [TestMethod]
        public void TestGoTo()
        {
            var elevator = new Modul7.Elevator("Elevator 1", 10, -2, 30, 0);
            var currentFloor = elevator.CurrentFloor;
            elevator.GoTo(elevator.CurrentFloor + 2);
            Assert.AreEqual(elevator.CurrentFloor, currentFloor + 2);
        }
    }
}
