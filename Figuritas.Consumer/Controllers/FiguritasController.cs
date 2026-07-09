using Figuritas.Abstractions.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Figuritas.Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiguritasController(IFiguritaService _figuritaService) : ControllerBase
    {
        [HttpGet("GetAllFiguritas")]
        public async Task<IActionResult> GetAllFiguritasAsync()
        {
            var figus = await _figuritaService.GetAllFiguritasAsync(); 
            if (figus.Count > 0)
            {
                return Ok(figus);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("getFigusByCountry/{country}")]
        public async Task<IActionResult> GetFigusByCountry(string country)
        {
            var figusCountry = await _figuritaService.GetFigusByCountry(country);
            if (figusCountry.Count > 0)
            {
                return Ok(figusCountry);
            }
            return NotFound("No se encontró ninguna figurita del país introducido");
        }

        [HttpGet("getFigusByID/{id}")]
        public async Task<IActionResult> GetFigusByID(string id)
        {
            var figusByID = await _figuritaService.GetFigusByID(id);
            if (figusByID.Count > 0)
            {
                return Ok(figusByID);
            }
            return NotFound("No se encontró ninguna figurita del ID introducido");
        }

    }
}
