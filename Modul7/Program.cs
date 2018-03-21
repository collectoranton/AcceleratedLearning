using System;

namespace Modul7
{
    class Program
    {
        static void Main(string[] args)
        {
            var elevator1 = new Elevator("Elevator 1", 10, -2, 0);

            Console.WriteLine($"Elevator {elevator1.ID} is on floor {elevator1.CurrentFloor}. It spans {elevator1.FloorCount} floors. It has traveled {elevator1.FloorsTraveled} floors.");

            elevator1.GoUp();
            elevator1.GoUp();
            elevator1.GoDown();

            Console.WriteLine($"Elevator {elevator1.ID} is on floor {elevator1.CurrentFloor}. It spans {elevator1.FloorCount} floors. It has traveled {elevator1.FloorsTraveled} floors.");

            elevator1.GoTo(10);
            elevator1.GoTo(5);
            elevator1.GoTo(4);
            elevator1.GoTo(5);


            Console.WriteLine($"Elevator {elevator1.ID} is on floor {elevator1.CurrentFloor}. It spans {elevator1.FloorCount} floors. It has traveled {elevator1.FloorsTraveled} floors.");
        }
    }
}
