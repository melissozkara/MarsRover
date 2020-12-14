using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Helpers
{
    public class SpinningControl
    {
        public Location GetNextDirection(char NextStep, Location current)
        {
            switch (current.Direction)
            {
                case "N":
                    current.Direction = (NextStep == 'L') ? "W" : "E";
                    break;
                case "E":
                    current.Direction = (NextStep == 'L') ? "N" : "S";
                    break;
                case "W":
                    current.Direction = (NextStep == 'L') ? "S" : "N";
                    break;
                case "S":
                    current.Direction = (NextStep == 'L') ? "E" : "W";
                    break;
            }

            return current;
        }
    }
}