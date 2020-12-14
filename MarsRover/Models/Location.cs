using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class Location  
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; } // baktığı yön 
    }
}
