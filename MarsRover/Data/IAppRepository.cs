using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Data
{
    public interface IAppRepository
    {
        Rectangle DefineRectangle(string Dimension);
        Location DefineLocation(string Position);
        Location FinalLocation(string way , Location start);
    }
}