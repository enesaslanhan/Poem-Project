using Businnes.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoemsController : ControllerBase
    {
        IPoemService _poemService;
        public PoemsController(
            IPoemService poemService)
        {
            _poemService = poemService;
        }
        [HttpPost("add")]
        public IActionResult Add(Poem poem) {
            var result = _poemService.Add(poem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _poemService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int poemId)
        {
            var result = _poemService.Delete(poemId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Poem poem)
        {
            var result = _poemService.Update(poem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserıd")] 
        public IActionResult GetByUserId(int userId)
        {
            var result = _poemService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbypoemid")]
        public IActionResult GetByPoemId(int poemId)
        {
            var result = _poemService.GetByPoemId(poemId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
