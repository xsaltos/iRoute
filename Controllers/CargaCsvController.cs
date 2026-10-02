
using iRoute.Data;
using iRoute.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace iRoute.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargaCsvController : Controller
    {
        private readonly AppDbContext _context;
        public CargaCsvController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("cargaArchivo")]
        public async Task<IActionResult> cargaArchivo([FromBody] CsvRequest requets)
        {
           if (requets == null) return BadRequest("Archivo vacio");
            foreach (var fila in requets.Data)
            {

                await _context.InsertaCommerce(fila.pcnumdoc ,fila.pcNomcomred, fila.pcprocessdate);
     
            }
            return Ok(new { mensaje = "Archivo cargdo correctamente", totalFilas = requets.Data.Count });
        
          }
    
      
        [HttpGet("consultarPorFecha")]
        public async Task<IActionResult> ConsultarPorFecha(DateTime fecha)
        {
            var recordSet = await _context.ConsultaCommerce();
            return Ok(recordSet);
        }
       /* [HttpGet("consultarErrores")]
        public async Task<IActionResult> ConsultarErrores()
        {
            var recordSet = await _context.ConsultaQuarantine();
            return Ok(recordSet);
        }*/
      
    }
}