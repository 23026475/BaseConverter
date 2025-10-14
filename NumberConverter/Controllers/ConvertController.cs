using Microsoft.AspNetCore.Mvc;
using NumberConverter.Models;
using NumberConverter.Service;

namespace NumberConverter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvertController : ControllerBase
    {
        private readonly ConverterService _converterService;

        // ✅ Dependency Injection
        public ConvertController(ConverterService converterService)
        {
            _converterService = converterService;
        }

        [HttpPost]
        public IActionResult Convert([FromBody] ConversionRequest request)
        {
            // ✅ Input validation
            if (string.IsNullOrWhiteSpace(request.Input))
            {
                return BadRequest(new { error = "Input cannot be empty." });
            }

            if (request.FromBase < 2 || request.FromBase > 16 ||
                request.ToBase < 2 || request.ToBase > 16)
            {
                return BadRequest(new { error = "Base must be between 2 and 16." });
            }

            try
            {
                var result = _converterService.ConvertNumber(request);
                return Ok(result); // returns 200 OK with JSON
            }
            catch (FormatException)
            {
                return BadRequest(new { error = $"Input '{request.Input}' is not valid for base {request.FromBase}." });
            }
            catch (Exception ex)
            {
                // Generic error handling
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
