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
    public class PoemGetScoresController : ControllerBase
    {
        IPoemGetScoreService _poemGetScoreService;
        public PoemGetScoresController(IPoemGetScoreService poemGetScoreService)
        {
            _poemGetScoreService = poemGetScoreService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _poemGetScoreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(PoemGetScore poemGetScore)
        {
            var result = _poemGetScoreService.Add(poemGetScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(PoemGetScore poemGetScore)
        {
            var result = _poemGetScoreService.Update(poemGetScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _poemGetScoreService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
