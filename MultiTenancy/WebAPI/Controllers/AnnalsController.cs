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
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _annalService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Annal annal)
        {
            _annalService.Add(annal);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Annal annal)
        {
            _annalService.Delete(annal);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update(Annal annal)
        {
            _annalService.Update(annal);
            return Ok();
        }
        
    }
}
