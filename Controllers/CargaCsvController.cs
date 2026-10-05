
using iRoute.Data;
using iRoute.DTO;
using iRoute.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
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
        public async Task<IActionResult> cargaArchivo(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return BadRequest("Archivo vacío");

            var lista = new List<CargaCsvDTO>();

            using var reader = new StreamReader(archivo.OpenReadStream());

            // Omitir cabecera
            await reader.ReadLineAsync();

            while (!reader.EndOfStream)
            {
                var linea = await reader.ReadLineAsync();
                var datos = linea.Split(';');

                lista.Add(new CargaCsvDTO
                {
                    pc_nomcomred = datos[0],
                    pc_numdoc = int.Parse(datos[1]),
                    pc_processdate = datos[2]
                });
            }

            string json = JsonSerializer.Serialize(lista);

            await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC sp_CargarComercios {json}"
            );

            return Ok();
        }





        [HttpGet("consultar/{fecha}")]
        public async Task<IActionResult> Consultar(DateTime fecha)
        {
            var resultado = await _context.Commerce
            .FromSqlInterpolated(
            $"EXEC consulta_commerce @fecha_consulta = {fecha}")
            .ToListAsync();

            return Ok(resultado);
        }
        /* [HttpGet("consultarErrores")]
         public async Task<IActionResult> ConsultarErrores()
         {
             var recordSet = await _context.ConsultaQuarantine();
             return Ok(recordSet);
         }*/

    }
}