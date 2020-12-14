using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Data;
using MarsRover.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        private IAppRepository _appRepository; 
        public RoverController(IAppRepository appRepository)
        {
            _appRepository = appRepository; 
        }


        [HttpGet("Access")]
        public ActionResult Access()
        {
            var msg = "Arrived to the Service";
            //var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(msg);
        }

        // POST api/values
        [HttpPost]
        [Route("SendRover")]
        public ActionResult Post([FromBody] EntryParameters entry)
        {
            var rectangleSize = _appRepository.DefineRectangle(entry.FirstParameter);  
            var FirstRoverStart = _appRepository.DefineLocation(entry.SecondParameter);  
            var SecondRoverStart = _appRepository.DefineLocation(entry.FourthParameter);  

            var FirstRoverStop = _appRepository.FinalLocation(entry.ThirdParameter, FirstRoverStart); 
            FirstRoverStop.X = (FirstRoverStop.X > rectangleSize.MaxX) ? rectangleSize.MaxX : FirstRoverStop.X; 
            FirstRoverStop.Y = (FirstRoverStop.Y > rectangleSize.MaxY) ? rectangleSize.MaxY : FirstRoverStop.Y; 
            var SecondRoverStop = _appRepository.FinalLocation(entry.FifthParameter , SecondRoverStart);  
            SecondRoverStop.X = (SecondRoverStop.X > rectangleSize.MaxX) ? rectangleSize.MaxX : SecondRoverStop.X; 
            SecondRoverStop.Y = (SecondRoverStop.Y > rectangleSize.MaxY) ? rectangleSize.MaxY : SecondRoverStop.Y; 

            string result = FirstRoverStop.X + " " + FirstRoverStop.Y + " " + FirstRoverStop.Direction; 
            result += " \r\n";  // satır atlamak için
            result += SecondRoverStop.X + " " + SecondRoverStop.Y + " " + SecondRoverStop.Direction;

            return Ok(result);
        }

    }
}
