using System;
using System.Collections.Generic;
using System.Text;

namespace Modul7
{
    public class Elevator
    {
        public string ID { get; }
        public int HighestFloor { get; }
        public int LowestFloor { get; }
        public int MaxTravelBeforeService { get; private set; }
        public int CurrentFloor { get; private set; }
        public int FloorCount { get => HighestFloor - LowestFloor; }
        public int FloorsTraveled { get; private set; } = 0;


        public Elevator(string iD, int highestFloor, int lowestFloor, int maxTravelBeforeService)
            : this(iD, highestFloor, lowestFloor, lowestFloor, maxTravelBeforeService)
        {
        }

        public Elevator(string iD, int highestFloor, int lowestFloor, int maxTravelBeforeService, int startFloor)
        {
            ID = iD;

            if (highestFloor <= lowestFloor)
                throw new ArgumentException("Highest floor can not be equal to, or lower than, the lowest floor");
            if (maxTravelBeforeService < 0)
                throw new ArgumentException("Max travel before service must be more than 0");

            HighestFloor = highestFloor;
            LowestFloor = lowestFloor;
            MaxTravelBeforeService = maxTravelBeforeService;

            if (startFloor > highestFloor)
                CurrentFloor = highestFloor;
            if (startFloor < lowestFloor)
                CurrentFloor = lowestFloor;
            CurrentFloor = startFloor;
        }

        public void GoUp()
        {
            if (CurrentFloor != HighestFloor)
            {
                CurrentFloor++;
                FloorsTraveled++;
            }
        }

        public void GoDown()
        {
            if (CurrentFloor != LowestFloor)
            {
                CurrentFloor--;
                FloorsTraveled++;
            }
        }

        public void GoTo(int floor)
        {
            if (floor >= LowestFloor && floor <= HighestFloor && floor != CurrentFloor)
            {
                if (floor < CurrentFloor)
                    FloorsTraveled += CurrentFloor - floor;

                if (floor > CurrentFloor)
                    FloorsTraveled += floor - CurrentFloor;

                CurrentFloor = floor;
            }
        }
    }
}
