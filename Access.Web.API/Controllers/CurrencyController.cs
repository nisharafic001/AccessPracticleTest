using Microsoft.AspNetCore.Mvc;
using System;

namespace Access.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        [HttpGet("{value}")]
        public IActionResult ConvertToWords(decimal value)
        {
            try
            {
                //if (value < 0)
                //{
                //    return BadRequest("Value cannot be negative.");
                //}
                string words = CurrencyConverter.ConvertToWords(value);
                return Ok(words);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }
    }
}
