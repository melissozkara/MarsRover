using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Helpers
{
    public class MovingControl
    {
        public Location MoveNextDirection(Location current)
        {
            switch (current.Direction)
            {
                case "N":
                    current.Y = current.Y + 1;
                    break;
                case "E":
                    current.X = current.X + 1;
                    break;
                case "W":
                    current.X = current.X - 1;
                    break;
                case "S":
                    current.Y = current.Y - 1;
                    break;
            }

            return current;
        }

    }
}