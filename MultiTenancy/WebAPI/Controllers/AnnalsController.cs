using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnalsController : ControllerBase
    {
        private readonly IAnnalService _annalService;

        public AnnalsController(IAnnalService annalService)
        {
            _annalService = annalService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _annalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _annalService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpGet("getwith")]
        //public async Task<IActionResult> GetRoomsPaged([FromQuery] RoomFilter roomFilter)
        //{
        //    // validasyon 
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    // IQueryCollection queryString = Request.Query;
        //    // roomFilter.RouteValues = queryString.ToRouteValues();
        //    roomFilter.RouteName = string.Concat(Request.Scheme, "://", Request.Host.Value);
        //    roomFilter.RouteValues = Request.Query.ToRouteValues();

        //    var rooms = await _roomService.GetRoomsPagedAsync(roomFilter);

        //    if (rooms.Data == null || !rooms.Data.Any())  //rooms.Data.Count() <= 0 ) /* 1 2 3 4 ... 10.000*/
        //        return NoContent();

        //    return Ok(rooms);


        //}

        [HttpPost("add")]
        [Authorize()]
        public IActionResult Add(Annal annal)
        {
            var result = _annalService.Add(annal);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        [Authorize()]
        public IActionResult Delete(Annal annal)
        {
            var result = _annalService.Delete(annal);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); ;
        }

        [HttpPost("update")]
        [Authorize()]
        public IActionResult Update(Annal annal)
        {
            var result = _annalService.Update(annal);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
