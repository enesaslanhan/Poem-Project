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
    public class PoemScoresController : ControllerBase
    {
        IPoemScoreService _poemScoreService;
        public PoemScoresController(IPoemScoreService poemScoreService)
        {
            _poemScoreService = poemScoreService;
        }
        [HttpPost("add")]
        public IActionResult Add(PoemScore poemScore)
        {
            var result = _poemScoreService.Add(poemScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(PoemScore poemScore)
        {
            var result = _poemScoreService.Delete(poemScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(PoemScore poemScore)
        {
            var result = _poemScoreService.Update(poemScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _poemScoreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserıd")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _poemScoreService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbypoemid")]
        public IActionResult GetByPoemId(int poemId)
        {
            var result = _poemScoreService.GetByPoemId(poemId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
