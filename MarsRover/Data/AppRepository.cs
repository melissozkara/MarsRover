using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Helpers;
using MarsRover.Models;

namespace MarsRover.Data
{
    public class AppRepository : IAppRepository
    {
        public Location DefineLocation(string Position) 
        {
            Location location = new Location();
            string[] Array;
            SplitFunction(Position, out Array);
            location.X = Convert.ToInt32(Array[0]);
            location.Y = Convert.ToInt32(Array[1]);
            location.Direction = Array[2];

            return location;
        }

        public Rectangle DefineRectangle(string Dimension) 
        {
            Rectangle rectangle = new Rectangle();
            string[] Array;
            SplitFunction(Dimension, out Array);
            rectangle.MaxX = Convert.ToInt32(Array[0]);
            rectangle.MaxY = Convert.ToInt32(Array[1]);

            return rectangle;
        }

        public Location FinalLocation(string way, Location start) 
        {
            Location stop = new Location();
            stop = start;
            foreach (var item in way)
            {
                if (item == 'L' || item == 'R')
                {
                    SpinningControl spin = new SpinningControl();
                    var data = spin.GetNextDirection(item, stop);
                    stop = data;
                }
                else
                {
                    MovingControl move = new MovingControl();
                    var data = move.MoveNextDirection(stop);
                    stop = data;
                }
            }

            return stop;
        }

        private void SplitFunction(string param, out string[] array)
        {
            array = param.Split(' ');
        }
    }
}
